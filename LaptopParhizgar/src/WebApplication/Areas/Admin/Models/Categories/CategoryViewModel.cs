using System.ComponentModel.DataAnnotations;
using WebApplication.Areas.Admin.Models.Shared;

namespace WebApplication.Areas.Admin.Models.Categories;
public class CategoryViewModel
{
    public long Id { get; set; }
    [Display(Name = " عنوان")]
    [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
    public string Title { get; set; }

    [Display(Name = "Slug")]
    [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
    public string Slug { get; set; }
    [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
    public SeoDataViewModel SeoDataViewModel { get; set; }
    public long? ParentId { get; set; }
}