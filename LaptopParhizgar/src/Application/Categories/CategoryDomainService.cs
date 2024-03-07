using Common.Application;
using Domain.Category.Repository;
using Domain.Category.Service;

namespace Application.Categories;
public class CategoryDomainService : ICategoryDomainService
{
    private readonly ICategoryRepository _repository;
    public CategoryDomainService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public OperationResult IsSlugExist(string slug)
    {
        var Exists = _repository.Exists(s => s.Slug == slug); //  اگر در سیستم وجود نداشت 0 رو برگشت میده
        if (Exists == false)
            return OperationResult.Success();

        return OperationResult.Error("Slug تکراری است");
    }
}