using Common.Application;
using Domain.Sliders;
using Microsoft.AspNetCore.Http;

namespace Application.Sliders.EditSliderPoster;
public class EditSliderPostersCommand : IBaseCommand
{
    public EditSliderPostersCommand(long sliderId, string link, IFormFile imageFile, ImageLocation imageLocation)
    {
        SliderId = sliderId;
        Link = link;
        ImageFile = imageFile;
        ImageLocation = imageLocation;
    }

    public long SliderId { get; set; }
    public string Link { get; set; }
    public IFormFile? ImageFile { get; set; }
    public ImageLocation ImageLocation { get; set; }

}