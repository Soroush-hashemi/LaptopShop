using Application.Sliders.Create;
using Application.Sliders.Delete;
using Application.Sliders.Edit;
using Common.Application;
using MediatR;
using Query.Sliders.DTO;
using Query.Sliders.GetById;
using Query.Sliders.GetList;
using Query.Sliders.GetListForIndex;

namespace PresentationFacade.Sliders;
public class SliderFacade : ISliderFacade
{
    private readonly IMediator _mediator;
    public SliderFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Task<OperationResult> Create(CreateSliderCommand command)
    {
        return _mediator.Send(command);
    }

    public Task<OperationResult> Delete(long SliderId)
    {
        return _mediator.Send(new DeleteSliderCommand(SliderId));
    }

    public Task<OperationResult> Edit(EditSliderCommand command)
    {
        return _mediator.Send(command);
    }

    public Task<List<SliderDto>> GetList()
    {
        return _mediator.Send(new GetSlidersListQuery());
    }

    public Task<List<SliderDto>> GetListForIndex()
    {
        return _mediator.Send(new GetSlidersForIndexQuery());
    }

    public Task<SliderDto> GetById(long Id)
    {
        return _mediator.Send(new GetSliderByIdQuery(Id));
    }
}