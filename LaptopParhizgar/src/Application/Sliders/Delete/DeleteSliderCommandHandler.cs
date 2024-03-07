using Common.Application;
using Common.Application.FileUtil;
using Common.Application.FileUtil.Interfaces;
using Common.Domain.Exceptions;
using Domain.Sliders.Repository;

namespace Application.Sliders.Delete;
public class DeleteSliderCommandHandler : IBaseCommandHandler<DeleteSliderCommand>
{
    private readonly ISliderRepository _repository;
    private readonly IFileService _fileService;
    public DeleteSliderCommandHandler(ISliderRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(DeleteSliderCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var slider = await _repository.GetTracking(request.SliderId);
            if (slider == null)
                return OperationResult.NotFound();

            _repository.DeleteSlider(slider);
            await _repository.Save();

            _fileService.DeleteFile(Directories.SliderImage, slider.ImageName);
            return OperationResult.Success();
        }
        catch (NullOrEmptyException ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }
}