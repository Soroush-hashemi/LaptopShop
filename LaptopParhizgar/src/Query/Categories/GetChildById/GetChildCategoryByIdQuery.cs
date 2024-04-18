using Common.Query;
using Query.Categories.DTOs;

namespace Query.Categories.GetChildById;
public record GetChildCategoryByIdQuery(long subCategoryId) : IQuery<SubCategoryDto>;