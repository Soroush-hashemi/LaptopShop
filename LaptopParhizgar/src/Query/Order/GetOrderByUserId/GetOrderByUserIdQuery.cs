using Common.Query;
using Query.Order.DTOs;

namespace Query.Order.GetOrderByUserId;
public record GetOrderByUserIdQuery(long userId) : IQuery<List<OrderDto>>;