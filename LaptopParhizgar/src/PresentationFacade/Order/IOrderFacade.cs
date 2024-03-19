using Application.Orders.Add;
using Application.Orders.SetOrderStateOnCanceled;
using Application.Orders.SetOrderStateOnDelivered;
using Common.Application;
using Query.Order.DTOs;
using Query.Order.GetOrderByUserId;
using Query.Order.GetOrderDetailsByOrderId;

namespace PresentationFacade.Order;
public interface IOrderFacade
{
    Task<OperationResult> Add(AddOrderCommand command);
    Task<OperationResult> SetOrderStateOnCanceled(SetOrderStateOnCanceledCommand command);
    Task<OperationResult> SetOrderStateOnDelivered(SetOrderStateOnDeliveredCommand command);

    Task<List<OrderDto>> GetAllOrders();
    Task<List<OrderDto>> GetByUserId(GetOrderByUserIdQuery query);
    Task<List<OrderDetailsDto>> GetByOrderId(GetOrderDetailsByOrderIdQuery query);
}