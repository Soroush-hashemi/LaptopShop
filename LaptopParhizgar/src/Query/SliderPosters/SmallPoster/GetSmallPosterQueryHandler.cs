using Common.Query;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Query.SliderPosters.DTO;

namespace Query.SliderPosters.SmallPoster;
public class GetSmallPosterQueryHandler : IQueryHandler<GetSmallPosterQuery, SliderPostersDto?>
{
    private readonly LaptopParhizgerContext _context;
    public GetSmallPosterQueryHandler(LaptopParhizgerContext context)
    {
        _context = context; 
    }

    public async Task<SliderPostersDto?> Handle(GetSmallPosterQuery request, CancellationToken cancellationToken)
    {
        var SmallPoster = await _context.SliderPosters.OrderByDescending(T => T.CreationDate)
             .Where(p => p.ImageLocation == Domain.Sliders.ImageLocation.SmallPoster).FirstOrDefaultAsync();

        var SmallPosterDto = new SliderPostersDto()
        {
            Image = SmallPoster.ImageName,
            Link = SmallPoster.Link,
            CreationDate = SmallPoster.CreationDate,
            ImageLocationDto = SmallPoster.ImageLocation,
        };

        return SmallPosterDto;
    }
}