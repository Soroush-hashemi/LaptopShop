using Common.Query;
using Query.SliderPosters.DTO;

namespace Query.SliderPosters.GetList;
public record GetSliderPosterListQuery : IQuery<List<SliderPostersDto>>;