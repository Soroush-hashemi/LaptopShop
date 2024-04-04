using Common.Query;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Query.SliderPosters.DTO;

namespace Query.SliderPosters.BigPoster;
public class GetBigPosterQueryHandler : IQueryHandler<GetBigPosterQuery, SliderPostersDto?>
{
    private readonly LaptopParhizgerContext _context;
    public GetBigPosterQueryHandler(LaptopParhizgerContext context)
    {
        _context = context;
    }

    public async Task<SliderPostersDto?> Handle(GetBigPosterQuery request, CancellationToken cancellationToken)
    {
        var BigPoster = await _context.SliderPosters.OrderByDescending(T => T.CreationDate)
            .Where(p => p.ImageLocation == Domain.Sliders.ImageLocation.BigPoster).FirstOrDefaultAsync();

        var BigPosterDto = new SliderPostersDto()
        {
            Image = BigPoster.ImageName,
            Link = BigPoster.Link,
            CreationDate = BigPoster.CreationDate,
            ImageLocationDto = BigPoster.ImageLocation,
        };

        return BigPosterDto;
    }
}