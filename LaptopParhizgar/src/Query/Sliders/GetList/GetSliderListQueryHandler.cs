using Common.Query;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Query.Sliders.DTO;

namespace Query.Sliders.GetList;
public class GetSliderListQueryHandler : IQueryHandler<GetSlidersQuery, List<SliderDto>>
{
    private readonly LaptopParhizgerContext _context;
    public GetSliderListQueryHandler(LaptopParhizgerContext context)
    {
        _context = context;
    }

    public async Task<List<SliderDto>> Handle(GetSlidersQuery request, CancellationToken cancellationToken)
    {
        return await _context.Slider.OrderByDescending(d => d.CreationDate)
            .Select(slider => new SliderDto()
            {
                Id = slider.Id,
                ImageName = slider.ImageName,
                Link = slider.Link,
            }).ToListAsync(cancellationToken);
    }
}