using Common.Application;
using Common.Domain.Exceptions;
using Domain.Category.Repository;
using Domain.Category.Service;

namespace Application.Categories.AddChild;
public class AddChildCategoryCommandHandler : IBaseCommandHandler<AddChildCategoryCommand, long>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICategoryDomainService _domainService;
    public AddChildCategoryCommandHandler(ICategoryRepository categoryRepository, ICategoryDomainService domainService)
    {
        _categoryRepository = categoryRepository;
        _domainService = domainService;
    }

    public async Task<OperationResult<long>> Handle(AddChildCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var category = await _categoryRepository.GetTracking(request.parentId);
            if (category == null)
                return OperationResult<long>.NotFound();

            category.AddChild(request.title, request.slug, request.SeoData, _domainService);
            await _categoryRepository.Save();
            return OperationResult<long>.Success(request.parentId);
        }
        catch (NullOrEmptyException ex)
        {
            return OperationResult<long>.Error(ex.Message);
        }
    }
}