using Common.Query;
using Infrastructure.Persistence;
using Query.SliderPosters.DTO;

namespace Query.SliderPosters.GetList;
public class GetSliderPosterListQueryHandler : IQueryHandler<GetSliderPosterListQuery, List<SliderPostersDto>>
{
    private readonly LaptopParhizgerContext _context;
    public GetSliderPosterListQueryHandler(LaptopParhizgerContext context)
    {
        _context = context;
    }

    public async Task<List<SliderPostersDto>> Handle(GetSliderPosterListQuery request, CancellationToken cancellationToken)
    {
        return _context.SliderPosters
            .OrderByDescending(x => x.CreationDate)
            .Select(command => new SliderPostersDto()
            {
                Id = command.Id,
                Link = command.Link,
                Image = command.ImageName,
                ImageLocationDto = command.ImageLocation,
            }).ToList();
    }
}