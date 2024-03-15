using Common.Query;
using Query.Order.DTOs;

namespace Query.Order.GetAllOrders;
public record GetAllOrdersQuery : IQuery<List<OrderDto>>;