using Application.Categories.AddChild;
using Application.Categories.Create;
using Application.Categories.Delete;
using Application.Categories.Edit;
using Common.Application;
using MediatR;
using Query.Categories.DTOs;
using Query.Categories.GetById;
using Query.Categories.GetByParentId;
using Query.Categories.GetBySlug;
using Query.Categories.GetChildById;
using Query.Categories.GetList;

namespace PresentationFacade.Categories;
public class CategoryFacade : ICategoryFacade
{
    private readonly IMediator _mediator;
    public CategoryFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult<long>> AddChild(AddChildCategoryCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult<long>> Create(CreateCategoryCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Delete(long CategoryId)
    {
        return await _mediator.Send(new DeleteCategoryCommand(CategoryId));
    }

    public async Task<OperationResult> Edit(EditCategoryCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<CategoryDto> GetById(long CategoryId)
    {
        return await _mediator.Send(new GetCategoryByIdQuery(CategoryId));
    }

    public async Task<List<SubCategoryDto>> GetByParentId(long ParentId)
    {
        return await _mediator.Send(new GetCategoryByParentIdQuery(ParentId));
    }

    public async Task<CategoryDto> GetBySlug(string slug)
    {
        return await _mediator.Send(new GetCategoryBySlugQuery(slug));
    }

    public async Task<SubCategoryDto> GetChildById(long SubCategoryId)
    {
        return await _mediator.Send(new GetChildCategoryByIdQuery(SubCategoryId));
    }

    public async Task<List<CategoryDto>> GetList()
    {
        return await _mediator.Send(new GetCategoryListQuery());
    }
}