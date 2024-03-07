using Common.Application;
using Common.Application.FileUtil;
using Common.Application.FileUtil.Interfaces;
using Common.Domain.Exceptions;
using Domain.Sliders.Repository;
using Microsoft.AspNetCore.Http;

namespace Application.Sliders.Edit;
public class EditSliderCommandHandler : IBaseCommandHandler<EditSliderCommand>
{
    private readonly ISliderRepository _repository;
    private readonly IFileService _fileService;
    public EditSliderCommandHandler(ISliderRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(EditSliderCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var Slider = await _repository.GetTracking(request.SliderId);
            if (Slider == null)
                return OperationResult.NotFound();

            var imageName = Slider.ImageName;
            var oldImage = Slider.ImageName;

            if (request.ImageFile != null)
                imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.SliderImage);

            Slider.Edit(request.Link, imageName);

            await _repository.Save();
            DeleteOldImage(request.ImageFile, oldImage);
            return OperationResult.Success();
        }
        catch (NullOrEmptyException ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }

    private void DeleteOldImage(IFormFile? imageFile, string oldImage)
    {
        if (imageFile != null)
            _fileService.DeleteFile(Directories.SliderImage, oldImage);
    }
}