﻿using MediatR;
using Application.Products.Create;
using Application.Products.Delete;
using Application.Products.Edit;
using Application.Products.IncreaseVisit;
using Common.Application;
using Query.Products.DTOs;
using Query.Products.GetByFilter;
using Query.Products.GetById;
using Query.Products.GetBySlug;

namespace PresentationFacade.Products;
public class ProductFacade : IProductFacade
{
    private readonly IMediator _mediator;
    public ProductFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> Create(CreateProductCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Delete(long Id)
    {
        return await _mediator.Send(new DeleteProductCommand(Id));
    }

    public async Task<OperationResult> Edit(EditProductCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<ProductFilterDto> GetByFilter(GetProductsByFilterQuery query)
    {
        return await _mediator.Send(query);
    }

    public async Task<ProductDto> GetById(GetProductByIdQuery query)
    {
        return await _mediator.Send(query);
    }

    public async Task<ProductDto> GetBySlug(GetProductBySlugQuery query)
    {
        return await _mediator.Send(query);
    }

    public async Task<OperationResult> IncreaseVisit(long Id)
    {
        return await _mediator.Send(new VisitProductCommand(Id));
    }
}