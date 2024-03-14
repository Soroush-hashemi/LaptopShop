using Microsoft.EntityFrameworkCore;
using Common.Query;
using Infrastructure.Persistence;
using Query.Sliders.DTO;
using Common.Application.FileUtil;

namespace Query.Sliders.GetById;
public class GetSliderByIdQueryHandler : IQueryHandler<GetSliderByIdQuery, SliderDto>
{
    private readonly LaptopParhizgerContext _context;
    public GetSliderByIdQueryHandler(LaptopParhizgerContext context)
    {
        _context = context;
    }

    public async Task<SliderDto> Handle(GetSliderByIdQuery request, CancellationToken cancellationToken)
    {
        var slider = await _context.Slider
            .FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);
        if (slider == null)
            return null;

        return new SliderDto()
        {
            Id = slider.Id,
            ImageName = slider.ImageName,
            Link = slider.Link,
        };
    }
}