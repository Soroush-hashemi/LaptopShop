using Query.Categories.DTOs;
using Common.Query;

namespace Query.Categories.GetList;
public record GetCategoryListQuery : IQuery<List<CategoryDto>>;