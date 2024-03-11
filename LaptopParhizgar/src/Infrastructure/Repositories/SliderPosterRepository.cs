using Domain.Sliders;
using Domain.Sliders.Repository;
using Infrastructure.Persistence;
using Infrastructure.Repositories.Base;
using System.Reflection;

namespace Infrastructure.Repositories;
public class SliderPostersRepository : BaseRepository<SliderPosters>, ISliderPostersRepository
{
    public SliderPostersRepository(LaptopParhizgerContext context) : base(context)
    {

    }

    public void DeleteSliderPosters(SliderPosters sliderPosters)
    {
        _context.SliderPosters.Remove(sliderPosters);
    }
}