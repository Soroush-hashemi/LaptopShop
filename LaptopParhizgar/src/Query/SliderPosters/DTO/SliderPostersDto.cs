using Common.Query.Bases;
using Domain.Sliders;
using Microsoft.AspNetCore.Http;

namespace Query.SliderPosters.DTO;
public class SliderPostersDto : BaseDto
{
    public string Image { get; set; }
    public IFormFile ImageFile { get; set; }
    public string Link { get; set; }
    public ImageLocation ImageLocation { get; set; }
}