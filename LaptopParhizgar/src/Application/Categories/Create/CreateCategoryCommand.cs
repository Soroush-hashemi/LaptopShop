using Common.Application;
using Common.Domain.ValueObjects;

namespace Application.Categories.Create;
public record CreateCategoryCommand(string title, string slug, SeoData seoData) : IBaseCommand<long>;