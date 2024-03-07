using Common.Application;

namespace Domain.Category.Service;
public interface ICategoryDomainService
{
    public OperationResult IsSlugExist(string slug);
}