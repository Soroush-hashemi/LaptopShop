using Common.Domain.Repository;

namespace Domain.Sliders.Repository;
public interface ISliderRepository : IBaseRepository<Slider>
{
    void DeleteSlider(Slider Slider);
}