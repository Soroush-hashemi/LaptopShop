using Common.Query;
using Infrastructure.Persistence;
using Query.SliderPosters.DTO;

namespace Query.SliderPosters.GetById;
public class GetSliderPosterByIdQueryHandler : IQueryHandler<GetSliderPosterByIdQuery, SliderPostersDto>
{
    private readonly LaptopParhizgerContext _context;
    public GetSliderPosterByIdQueryHandler(LaptopParhizgerContext context)
    {
        _context = context;
    }

    public async Task<SliderPostersDto> Handle(GetSliderPosterByIdQuery request, CancellationToken cancellationToken)
    {
        var SliderPosters = _context.SliderPosters.FirstOrDefault(s => s.Id == request.Id);
        if (SliderPosters == null)
            return null;

        var sliderPosters = new SliderPostersDto()
        {
            Id = request.Id,
            Link = SliderPosters.Link,
            Image = SliderPosters.ImageName,
            ImageLocationDto = SliderPosters.ImageLocation,
        };
        return sliderPosters;
    }
}