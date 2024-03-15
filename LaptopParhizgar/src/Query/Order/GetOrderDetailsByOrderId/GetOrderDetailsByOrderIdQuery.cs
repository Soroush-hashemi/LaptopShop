using Common.Query;
using Query.Order.DTOs;

namespace Query.Order.GetOrderDetailsByOrderId;
public record GetOrderDetailsByOrderIdQuery(long OrderId): IQuery<List<OrderDetailsDto>>;