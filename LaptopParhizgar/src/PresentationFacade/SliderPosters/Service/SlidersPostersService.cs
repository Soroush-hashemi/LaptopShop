using Infrastructure.Persistence;
using Query.SliderPosters.DTO;

namespace PresentationFacade.SliderPosters.Service;
public class SlidersPostersService : ISlidersPostersService
{
    private readonly LaptopParhizgerContext _context;
    public SlidersPostersService(LaptopParhizgerContext context)
    {
        _context = context;
    }

    public SliderPostersDto? GetBigPoster()
    {
        var BigPoster = _context.SliderPosters.OrderByDescending(T => T.CreationDate)
            .Where(p => p.ImageLocation == Domain.Sliders.ImageLocation.BigPoster).FirstOrDefault();

        if (BigPoster == null)
        {
            return null;
        }

        var BigPosterDto = new SliderPostersDto()
        {
            Image = BigPoster.ImageName,
            Link = BigPoster.Link,
            CreationDate = BigPoster.CreationDate,
            ImageLocationDto = BigPoster.ImageLocation,
        };

        return BigPosterDto;
    }

    public SliderPostersDto? GetCenterPoster()
    {
        var CenterPoster = _context.SliderPosters.OrderByDescending(T => T.CreationDate)
            .Where(p => p.ImageLocation == Domain.Sliders.ImageLocation.CenterPoster).FirstOrDefault();

        if (CenterPoster == null)
        {
            return null;
        }

        var CenterPosterDto = new SliderPostersDto()
        {
            Image = CenterPoster.ImageName,
            Link = CenterPoster.Link,
            CreationDate = CenterPoster.CreationDate,
            ImageLocationDto = CenterPoster.ImageLocation,
        };

        return CenterPosterDto;
    }

    public List<SliderPostersDto?> GetSmallPoster()
    {
        var smallPosters = _context.SliderPosters
            .Where(p => p.ImageLocation == Domain.Sliders.ImageLocation.SmallPoster)
            .OrderByDescending(T => T.CreationDate).ToList();

        if (smallPosters == null)
        {
            return null;
        }

        List<SliderPostersDto> smallPosterDtoList = new List<SliderPostersDto>();

        foreach (var smallPoster in smallPosters)
        {
            var smallPosterDto = new SliderPostersDto
            {
                Image = smallPoster.ImageName,
                Link = smallPoster.Link,
                ImageLocationDto = smallPoster.ImageLocation
            };

            smallPosterDtoList.Add(smallPosterDto);
        }

        return smallPosterDtoList;
    }
}