using Application.Sliders.Create;
using Application.Sliders.Edit;
using Common.Application;
using Query.Sliders.DTO;

namespace PresentationFacade.Sliders;
public interface ISliderFacade
{
    Task<OperationResult> Create(CreateSliderCommand command);
    Task<OperationResult> Edit(EditSliderCommand command);
    Task<OperationResult> Delete(long SliderId);

    Task<SliderDto> GetById(long Id);
    Task<List<SliderDto>> GetList();
    Task<List<SliderDto>> GetListForIndex();
}