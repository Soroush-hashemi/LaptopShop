using Common.Application;

namespace Domain.Products.Service;
public interface IProductDomainService
{
    public OperationResult IsSlugExist(string slug);
}