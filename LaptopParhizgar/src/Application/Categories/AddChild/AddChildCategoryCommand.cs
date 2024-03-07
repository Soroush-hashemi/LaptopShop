using Common.Application;
using Common.Domain.ValueObjects;

namespace Application.Categories.AddChild;
public record AddChildCategoryCommand(long parentId, string title, string slug, SeoData SeoData) : IBaseCommand<long>;