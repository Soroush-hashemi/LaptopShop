using Application.Sliders.CreateSliderPosters;
using Application.Sliders.DeleteSliderPoster;
using Application.Sliders.EditSliderPoster;
using Common.Application;
using Query.SliderPosters.DTO;

namespace PresentationFacade.SliderPosters;
public interface ISlidersPostersFacade
{
    Task<OperationResult> Create(CreateSliderPostersCommand command);
    Task<OperationResult> Edit(EditSliderPostersCommand command);
    Task<OperationResult> Delete(DeleteSliderPostersCommand command);
    
    Task<SliderPostersDto> GetById(long Id);
    Task<SliderPostersDto> GetSmallPoster();
    Task<SliderPostersDto> GetCenterPoster();
    Task<SliderPostersDto> GetBigPoster();
    Task<List<SliderPostersDto>> GetList();
}