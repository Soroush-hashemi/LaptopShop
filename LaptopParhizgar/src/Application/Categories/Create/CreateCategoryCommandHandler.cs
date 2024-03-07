using Common.Application;
using Common.Domain.Exceptions;
using Domain.Category;
using Domain.Category.Repository;
using Domain.Category.Service;

namespace Application.Categories.Create;
public class CreateCategoryCommandHandler : IBaseCommandHandler<CreateCategoryCommand, long>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICategoryDomainService _domainService;
    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, ICategoryDomainService domainService)
    {
        _categoryRepository = categoryRepository;
        _domainService = domainService;
    }

    public async Task<OperationResult<long>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var category = new Category(request.title, request.slug, request.seoData, _domainService);

            _categoryRepository.Add(category);
            await _categoryRepository.Save();
            return OperationResult<long>.Success(category.Id);
        }
        catch (NullOrEmptyException ex)
        {
            return OperationResult<long>.Error(ex.Message);
        }
    }
}
