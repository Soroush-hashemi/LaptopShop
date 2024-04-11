using Application.Products.Create;
using Application.Products.Edit;
using Common.Application;
using Query.Products.DTOs;
using Query.Products.GetByFilter;
using Query.Products.GetById;
using Query.Products.GetBySlug;

namespace PresentationFacade.Products;
public interface IProductsFacade
{
    Task<OperationResult> Create(CreateProductCommand command);
    Task<OperationResult> Edit(EditProductCommand command);
    Task<OperationResult> Delete(long Id);

    Task<ProductFilterDto> GetByFilter(GetProductsByFilterQuery query);
    Task<ProductDto> GetById(GetProductByIdQuery query);
    Task<ProductDto> GetBySlug(GetProductBySlugQuery query);
}