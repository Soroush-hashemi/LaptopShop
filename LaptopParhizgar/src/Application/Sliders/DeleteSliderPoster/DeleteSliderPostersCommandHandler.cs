using Application.Sliders.Delete;
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Application.FileUtil;
using Domain.Sliders.Repository;
using Common.Domain.Exceptions;

namespace Application.Sliders.DeleteSliderPoster;
public class DeleteSliderPostersCommandHandler : IBaseCommandHandler<DeleteSliderPostersCommand>
{
    private readonly ISliderPostersRepository _repository;
    private readonly IFileService _fileService;
    public DeleteSliderPostersCommandHandler(ISliderPostersRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(DeleteSliderPostersCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var sliderPoster = await _repository.GetTracking(request.SliderPosterId);
            if (sliderPoster == null)
                return OperationResult.NotFound();

            _repository.DeleteSliderPosters(sliderPoster);
            await _repository.Save();

            _fileService.DeleteFile(Directories.SliderPosterImage, sliderPoster.ImageName);
            return OperationResult.Success();
        }
        catch (NullOrEmptyException ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }
}