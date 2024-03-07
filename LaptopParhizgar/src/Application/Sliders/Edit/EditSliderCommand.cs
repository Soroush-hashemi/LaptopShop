using Common.Application;
using Microsoft.AspNetCore.Http;

namespace Application.Sliders.Edit;
public class EditSliderCommand : IBaseCommand
{
    public EditSliderCommand(long sliderId, string link, IFormFile imageFile)
    {
        SliderId = sliderId;
        Link = link;
        ImageFile = imageFile;
    }

    public long SliderId { get; set; }
    public string Link { get; set; }
    public IFormFile? ImageFile { get; set; }
}