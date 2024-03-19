﻿using Application.Orders.Add;
using Application.Orders.SetOrderStateOnCanceled;
using Application.Orders.SetOrderStateOnDelivered;
using Common.Application;
using MediatR;
using Query.Order.DTOs;
using Query.Order.GetAllOrders;
using Query.Order.GetOrderByUserId;
using Query.Order.GetOrderDetailsByOrderId;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PresentationFacade.Order;
public class OrderFacade : IOrderFacade
{
    private readonly IMediator _mediator;
    public OrderFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> Add(AddOrderCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> SetOrderStateOnCanceled(SetOrderStateOnCanceledCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> SetOrderStateOnDelivered(SetOrderStateOnDeliveredCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<List<OrderDto>> GetAllOrders()
    {
        return await _mediator.Send(new GetAllOrdersQuery());
    }

    public async Task<List<OrderDto>> GetByUserId(GetOrderByUserIdQuery query)
    {
        return await _mediator.Send(query);
    }

    public async Task<List<OrderDetailsDto>> GetByOrderId(GetOrderDetailsByOrderIdQuery query)
    {
        return await _mediator.Send(query);
    }
}