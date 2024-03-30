using Application.Sliders.CreateSliderPosters;
using Application.Sliders.DeleteSliderPoster;
using Application.Sliders.EditSliderPoster;
using Common.Application;
using MediatR;
using Query.SliderPosters.DTO;
using Query.SliderPosters.GetById;
using Query.SliderPosters.GetList;

namespace PresentationFacade.SliderPosters;
public class SliderPostersFacade : ISlidersPostersFacade
{
    private readonly IMediator _mediator;
    public SliderPostersFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> Create(CreateSliderPostersCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Delete(DeleteSliderPostersCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditSliderPostersCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<SliderPostersDto> GetById(long Id)
    {
        return await _mediator.Send(new GetSliderPosterByIdQuery(Id));
    }

    public async Task<List<SliderPostersDto>> GetList()
    {
        return await _mediator.Send(new GetSliderPosterListQuery());
    }
}