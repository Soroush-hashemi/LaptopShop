using Common.Query;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Query.Sliders.DTO;

namespace Query.Sliders.GetListForIndex;
public class GetSlidersForIndexQueryHandler : IQueryHandler<GetSlidersForIndexQuery, List<SliderDto>>
{
    private readonly LaptopParhizgerContext _context;
    public GetSlidersForIndexQueryHandler(LaptopParhizgerContext context)
    {
        _context = context;
    }

    public async Task<List<SliderDto>> Handle(GetSlidersForIndexQuery request, CancellationToken cancellationToken)
    {
        return await _context.Slider.OrderByDescending(d => d.CreationDate)
            .Select(slider => new SliderDto()
            {
                Id = slider.Id,
                ImageName = slider.ImageName,
                Link = slider.Link,
            }).Take(5).ToListAsync(cancellationToken);

    }
}