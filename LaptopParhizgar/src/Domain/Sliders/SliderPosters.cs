using Common.Domain.Bases;
using Common.Domain.Exceptions;

namespace Domain.Sliders;
public class SliderPosters : BaseEntity
{
    public string ImageName { get; private set; }
    public string Link { get; private set; }
    public ImageLocation imageLocation { get; private set; }

    public SliderPosters(string link, string imageName)
    {
        Guard(link, imageName);
        Link = link;
        ImageName = imageName;
    }

    public void Edit(string link, string imageName)
    {
        Guard(link, imageName);
        Link = link;
        ImageName = imageName;
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