using Common.Application;

namespace Application.Products.IncreaseVisit;
public record VisitProductCommand(long ProductId) : IBaseCommand;