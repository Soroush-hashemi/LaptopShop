using Common.Query;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
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
        var result = await _context.SliderPosters
            .OrderByDescending(x => x.Id)
            .Select(command => new SliderPostersDto()
            {
                Id = command.Id,
                Link = command.Link,
                Image = command.ImageName,
                ImageLocationDto = command.ImageLocation,
            }).ToListAsync();

        return result;
    }
}