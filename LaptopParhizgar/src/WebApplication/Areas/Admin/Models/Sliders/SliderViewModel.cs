using System.ComponentModel.DataAnnotations;

namespace WebApplication.Areas.Admin.Models.Sliders;
public class SliderViewModel
{
    public long Id { get; set; }

    [Display(Name = "لینک")]
    [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
    public string Link { get; set; }

    public string ImageName { get; set; }
    [Display(Name = "عکس")]
    [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
    public IFormFile ImageFile { get; set; }
}