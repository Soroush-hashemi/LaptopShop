using Common.Application;
using Domain.Products.Repository;

namespace Application.Products.IncreaseVisit;
public class VisitProductCommandHandler : IBaseCommandHandler<VisitProductCommand>
{
    private readonly IProductRepository _repository;
    public VisitProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(VisitProductCommand request, CancellationToken cancellationToken)
    {
        var Product = await _repository.GetTracking(request.ProductId);
        if (Product != null)
        {
            Product.Visit += 1;
            await _repository.Save();
            return OperationResult.Success();
        }
        return OperationResult.Error();
    }
}