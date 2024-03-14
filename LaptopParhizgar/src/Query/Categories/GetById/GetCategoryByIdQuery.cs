using Common.Query;
using Query.Categories.DTOs;

namespace Query.Categories.GetById;
public record GetCategoryByIdQuery(long CategoryId) : IQuery<CategoryDto>;