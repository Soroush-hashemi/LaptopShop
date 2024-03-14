using Common.Query.Bases;
using Query.SeoData;

namespace Query.Categories.DTOs;
public class CategoryDto : BaseDto
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public SeoDataDto seoDataDto { get; set; }
    public List<SubCategoryDto> Childs { get; set; }
}