using Common.Query;
using Query.Categories.DTOs;

namespace Query.Categories.GetByParentId;
public record GetCategoryByParentIdQuery(long ParentId) : IQuery<List<SubCategoryDto>>;