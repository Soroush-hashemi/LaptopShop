using Common.Application;
using Domain.Sliders;
using Microsoft.AspNetCore.Http;

namespace Application.Sliders.CreateSliderPosters;
public class CreateSliderPostersCommand : IBaseCommand
{
    public CreateSliderPostersCommand(string link, ImageLocation imageLocation, IFormFile imageFile)
    {
        Link = link;
        ImageLocation = imageLocation;
        ImageFile = imageFile;
    }

    public string Link { get; set; }
    public ImageLocation ImageLocation { get; set; }
    public IFormFile ImageFile { get; set; }
}