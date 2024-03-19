using Common.Query;
using Query.Sliders.DTO;

namespace Query.Sliders.GetListForIndex;
public record GetSlidersForIndexQuery : IQuery<List<SliderDto>>;