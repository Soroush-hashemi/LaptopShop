using Query.SliderPosters.DTO;

namespace PresentationFacade.SliderPosters.Service;
public interface ISlidersPostersService
{
    public List<SliderPostersDto?> GetSmallPoster();
    public SliderPostersDto? GetCenterPoster();
    public SliderPostersDto? GetBigPoster();
}