using Application.Orders.Add;
using Common.Application;
using Query.Order.DTOs;
using Query.Order.GetOrderByUserId;

namespace PresentationFacade.Order;
public interface IOrderFacade
{
    Task<OperationResult> Add(AddOrderCommand command);
    Task<OperationResult> SetOrderStateOnCanceled(long OrderId);
    Task<OperationResult> SetOrderStateOnDelivered(long OrderId);

    Task<List<OrderDto>> GetAllOrders();
    Task<List<OrderDto>> GetByUserId(GetOrderByUserIdQuery query);
    Task<List<OrderDetailsDto>> GetByOrderId(long OrderId);
}