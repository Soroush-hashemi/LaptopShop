using Common.Application;
using Common.Application.FileUtil;
using Common.Application.FileUtil.Interfaces;
using Common.Domain.Exceptions;
using Domain.Sliders;
using Domain.Sliders.Repository;

namespace Application.Sliders.CreateSliderPosters;
public class CreateSliderPostersCommandHandler : IBaseCommandHandler<CreateSliderPostersCommand>
{
    private readonly ISliderPostersRepository _repository;
    private readonly IFileService _fileService;

    public CreateSliderPostersCommandHandler(ISliderPostersRepository repository , IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(CreateSliderPostersCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var ImageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.SliderPosterImage);
            var slider = new SliderPosters(request.Link, ImageName , request.ImageLocation);

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