using Common.Query;
using Infrastructure.Persistence;
using Query.Order.DTOs;

namespace Query.Order.GetAllOrders;
public class GetAllOrdersQueryHandler : IQueryHandler<GetAllOrdersQuery, List<OrderDto>>
{
    private readonly LaptopParhizgerContext _context;
    public GetAllOrdersQueryHandler(LaptopParhizgerContext context)
    {
        _context = context;
    }

    public async Task<List<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        List<OrderDto> orderDto = new List<OrderDto>();
        var orders = _context.Orders.OrderByDescending(d => d.CreationDate).ToList();
        foreach (var orderItem in orders)
        {
            var OrderDetails = _context.OrderDetails.FirstOrDefault(p => p.OrderId == orderItem.Id);
            var RequestPay = _context.RequestPay.FirstOrDefault(p => p.Id == orderItem.RequestPayId);
            var User = _context.Users.FirstOrDefault(p => p.Id == orderItem.UserId);

            orderDto.Add(new OrderDto
            {
                Id = orderItem.Id,
                OrderState = orderItem.OrderState,
                RequestPayId = orderItem.RequestPayId,
                UserName = User.UserName,
                AddressId = orderItem.AddressId,
                CreationDate = orderItem.CreationDate,
                TotalPrice = RequestPay.Amount,
                OrderDetailsId = OrderDetails.Id,
            });
        }
        return orderDto;
    }
}