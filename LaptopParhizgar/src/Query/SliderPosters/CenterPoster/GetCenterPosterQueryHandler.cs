using Common.Query;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Query.SliderPosters.DTO;

namespace Query.SliderPosters.CenterPoster;
public class GetCenterPosterQueryHandler : IQueryHandler<GetCenterPosterQuery, SliderPostersDto?>
{
    private readonly LaptopParhizgerContext _context;
    public GetCenterPosterQueryHandler(LaptopParhizgerContext context)
    {
        _context = context;
    }

    public async Task<SliderPostersDto?> Handle(GetCenterPosterQuery request, CancellationToken cancellationToken)
    {
        var CenterPoster = await _context.SliderPosters.OrderByDescending(T => T.CreationDate)
             .Where(p => p.ImageLocation == Domain.Sliders.ImageLocation.CenterPoster).FirstOrDefaultAsync();

        var CenterPosterDto = new SliderPostersDto()
        {
            Image = CenterPoster.ImageName,
            Link = CenterPoster.Link,
            CreationDate = CenterPoster.CreationDate,
            ImageLocationDto = CenterPoster.ImageLocation,
        };

        return CenterPosterDto;
    }
}