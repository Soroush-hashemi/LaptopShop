using Common.Query;
using Query.SliderPosters.DTO;

namespace Query.SliderPosters.GetById;
public record GetSliderPosterByIdQuery(long Id) : IQuery<SliderPostersDto>;