using Common.Domain.Bases;
using Common.Domain.Exceptions;

namespace Domain.Sliders;
public class SliderPosters : BaseEntity
{
    public string ImageName { get; private set; }
    public string Link { get; private set; }
    public ImageLocation ImageLocation { get; private set; }

    private SliderPosters()
    {
        
    }

    public SliderPosters(string link, string imageName , ImageLocation imageLocation)
    {
        Guard(link, imageName);
        Link = link;
        ImageName = imageName;
        ImageLocation = imageLocation;
    }

    public void Edit(string link, string imageName , ImageLocation imageLocation)
    {
        Guard(link, imageName);
        Link = link;
        ImageName = imageName;
        ImageLocation = imageLocation;
    }

    public void Guard(string link, string imageName)
    {
        NullOrEmptyException.CheckString(link, nameof(link));
        NullOrEmptyException.CheckString(imageName, nameof(imageName));
    }
}

public enum ImageLocation
{
    BigPoster = 0,
    CenterPoster = 1,
    SmallPoster = 2
}