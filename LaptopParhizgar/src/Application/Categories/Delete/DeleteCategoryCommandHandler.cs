using Common.Application;
using Domain.Category.Repository;

namespace Application.Categories.Delete;
public class DeleteCategoryCommandHandler : IBaseCommandHandler<DeleteCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<OperationResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var result = _categoryRepository.DeleteCategory(request.CategoryId);
        if (result == true)
        {
            _categoryRepository.Save();
            return OperationResult.Success();
        }
        return OperationResult.Error("امکان حذف این دسته بندی وجود ندارد");
    }
}