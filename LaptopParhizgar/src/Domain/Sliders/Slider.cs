using Common.Domain.Bases;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;

namespace Domain.Sliders;
public class Slider : BaseEntity
{
    public string ImageName { get; private set; }
    public string Link { get; private set; }
    public SeoData SeoData { get; private set; }

    public Slider(string link, string imageName, SeoData seoData)
    {
        Guard(link, imageName);
        Link = link;
        ImageName = imageName;
        SeoData = seoData;
    }

    public void Edit(string link, string imageName, SeoData seoData)
    {
        Guard(link, imageName);
        Link = link;
        ImageName = imageName;
        SeoData = seoData;
    }

    public void Guard(string link, string imageName)
    {
        NullOrEmptyException.CheckString(link, nameof(link));
        NullOrEmptyException.CheckString(imageName, nameof(imageName));
    }
}