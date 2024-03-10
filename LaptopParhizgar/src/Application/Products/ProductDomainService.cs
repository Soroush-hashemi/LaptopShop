using Common.Application;
using Domain.Products.Repository;
using Domain.Products.Service;

namespace Application.Products;
public class ProductDomainService : IProductDomainService
{
    private readonly IProductRepository _repository;
    public ProductDomainService(IProductRepository repository)
    {
        _repository = repository;
    }

    public OperationResult IsSlugExist(string slug)
    {
        var Exists = _repository.Exists(s => s.Slug == slug); // اگر در سیستم وجود نداشت 0 رو برگشت میده
        if (Exists == false)
            return OperationResult.Success();

        return OperationResult.Error("Slug تکراری است");
    }
}