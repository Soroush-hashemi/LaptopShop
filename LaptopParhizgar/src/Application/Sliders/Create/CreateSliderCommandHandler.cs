using Common.Application;
using Common.Application.FileUtil;
using Common.Application.FileUtil.Interfaces;
using Common.Domain.Exceptions;
using Domain.Sliders;
using Domain.Sliders.Repository;

namespace Application.Sliders.Create;
public class CreateSliderCommandHandler : IBaseCommandHandler<CreateSliderCommand>
{
    private readonly ISliderRepository _repository;
    private readonly IFileService _fileService;
    public CreateSliderCommandHandler(ISliderRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(CreateSliderCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var ImageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.SliderImage);
            var slider = new Slider(request.Link, ImageName);

            _repository.Add(slider);
            await _repository.Save();
            return OperationResult.Success();
        }
        catch (NullOrEmptyException ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }
}