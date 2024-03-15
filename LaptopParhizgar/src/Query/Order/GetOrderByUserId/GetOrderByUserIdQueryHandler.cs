using Common.Query;
using Infrastructure.Persistence;
using Query.Order.DTOs;

namespace Query.Order.GetOrderByUserId;
public class GetOrderByUserIdQueryHandler : IQueryHandler<GetOrderByUserIdQuery, List<OrderDto>>
{
    private readonly LaptopParhizgerContext _context;
    public GetOrderByUserIdQueryHandler(LaptopParhizgerContext context)
    {
        _context = context;
    }

    public async Task<List<OrderDto>> Handle(GetOrderByUserIdQuery request, CancellationToken cancellationToken)
    {
        var Orders = _context.Orders.Where(p => p.UserId == request.userId).OrderByDescending(d => d.CreationDate);

        List<OrderDetailsDto> OrderDetailsDto = new List<OrderDetailsDto>();
        List<OrderDto> orderDto = new List<OrderDto>();

        if (Orders != null)
        {
            foreach (var item in Orders)
            {
                var OrderDetails = _context.OrderDetails.Where(p => p.OrderId == item.Id);

                foreach (var items in OrderDetails)
                {
                    var Product = _context.Products.Where(p => p.Id == items.ProductId);
                    foreach (var product in Product)
                    {
                        OrderDetailsDto.Add(new OrderDetailsDto
                        {
                            Id = items.Id,
                            Count = items.Count,
                            ProductId = items.ProductId,
                            ProductName = product.Title,
                            Price = items.Price,
                        });
                    }
                }

                var RequestPay = _context.RequestPay.Where(p => p.Id == item.RequestPayId).FirstOrDefault();

                orderDto.Add(new OrderDto
                {
                    AddressId = item.AddressId,
                    UserId = request.userId,
                    Id = item.Id,
                    CreationDate = item.CreationDate,
                    RequestPayId = item.RequestPayId,
                    OrderState = item.OrderState,
                    Price = RequestPay.Amount,
                    OrderDetails = OrderDetailsDto,
                });
            }
            return orderDto;
        }
        return new List<OrderDto>();
    }
}