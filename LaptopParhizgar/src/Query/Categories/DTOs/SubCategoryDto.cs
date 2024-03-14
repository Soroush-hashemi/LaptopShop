using Common.Query.Bases;
using Query.SeoData;

namespace Query.Categories.DTOs;
public class SubCategoryDto : BaseDto
{
    public long ParentId { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public SeoDataDto seoDataDto { get; set; }
}