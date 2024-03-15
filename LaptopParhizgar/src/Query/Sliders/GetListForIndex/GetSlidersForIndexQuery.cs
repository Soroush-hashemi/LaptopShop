using Common.Query;
using Query.Sliders.DTO;

namespace Query.Sliders.GetSliders;
public record GetSlidersForIndexQuery : IQuery<List<SliderDto>>;