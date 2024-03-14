using Common.Query;
using Query.Categories.DTOs;

namespace Query.Categories.GetBySlug;
public record GetCategoryBySlugQuery(string slug) : IQuery<CategoryDto>;