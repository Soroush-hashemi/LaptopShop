using Common.Domain.Repository;

namespace Domain.Sliders.Repository;
public interface ISliderPostersRepository : IBaseRepository<SliderPosters>
{
    void DeleteSliderPosters(SliderPosters sliderPosters);
}