using Common.Application;
using Microsoft.AspNetCore.Http;

namespace Application.Sliders.Create;
public class CreateSliderCommand : IBaseCommand
{
    public CreateSliderCommand(string link , IFormFile imageFile)
    {
        Link = link;
        ImageFile = imageFile;
    }

    public string Link { get; set; }
    public IFormFile ImageFile { get; set; }
}