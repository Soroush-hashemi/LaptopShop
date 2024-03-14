using Common.Query.Bases;
using Microsoft.AspNetCore.Http;

namespace Query.Sliders.DTO;
public class SliderDto : BaseDto
{
    public string Link { get; set; }
    public string ImageName { get; set; }
}