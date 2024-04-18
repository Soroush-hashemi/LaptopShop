using Application.Categories.AddChild;
using Application.Categories.Create;
using Application.Categories.Edit;
using Common.Application;
using Query.Categories.DTOs;

namespace PresentationFacade.Categories;
public interface ICategoryFacade
{
    Task<OperationResult<long>> Create(CreateCategoryCommand command);
    Task<OperationResult<long>> AddChild(AddChildCategoryCommand command);
    Task<OperationResult> Delete(long CategoryId);
    Task<OperationResult> Edit(EditCategoryCommand command);

    Task<CategoryDto> GetBySlug(string slug);
    Task<CategoryDto> GetById(long CategoryId);
    Task<SubCategoryDto> GetChildById(long SubCategoryId);
    Task<List<SubCategoryDto>> GetByParentId(long ParentId);
    Task<List<CategoryDto>> GetList();
}