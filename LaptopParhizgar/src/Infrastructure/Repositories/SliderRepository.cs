using Domain.Sliders;
using Domain.Sliders.Repository;
using Infrastructure.Persistence;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories;
public class SliderRepository : BaseRepository<Slider>, ISliderRepository
{
    public SliderRepository(LaptopParhizgerContext context) : base(context)
    {
    }

    public void DeleteSlider(Slider Slider)
    {
        _context.Slider.Remove(Slider);
    }
}