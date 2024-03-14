using Common.Query;
using Query.Sliders.DTO;

namespace Query.Sliders.GetById;
public record GetSliderByIdQuery(long Id) : IQuery<SliderDto>;