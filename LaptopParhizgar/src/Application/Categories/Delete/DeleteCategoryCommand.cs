using Common.Application;

namespace Application.Categories.Delete;
public record DeleteCategoryCommand(long CategoryId) : IBaseCommand;