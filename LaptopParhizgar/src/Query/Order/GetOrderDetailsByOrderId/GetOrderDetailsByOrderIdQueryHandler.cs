using Common.Query;
using Infrastructure.Persistence;
using MediatR;
using Query.Order.DTOs;
using Query.Order.GetOrderByUserId;

namespace Query.Order.GetOrderDetailsByOrderId;
public class GetOrderDetailsByOrderIdQueryHandler : IQueryHandler<GetOrderDetailsByOrderIdQuery, List<OrderDetailsDto>>
{
    private readonly LaptopParhizgerContext _context;
    private readonly IMediator _mediator;
    public GetOrderDetailsByOrderIdQueryHandler(LaptopParhizgerContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<List<OrderDetailsDto>> Handle(GetOrderDetailsByOrderIdQuery request, CancellationToken cancellationToken)
    {
        List<OrderDetailsDto> OrderDetailsDto = new List<OrderDetailsDto>();
        List<OrderDto> orderDto = new List<OrderDto>();

        var Order = _context.Orders.Where(p => p.Id == request.OrderId).FirstOrDefault();
        orderDto = await _mediator.Send(new GetOrderByUserIdQuery(request.OrderId));

        if (orderDto != null)
        {
            foreach (var item in orderDto)
            {
                var OrderDetails = _context.OrderDetails.Where(p => p.OrderId == request.OrderId);
                foreach (var items in OrderDetails)
                {
                    var RequestPayId = _context.Orders.Where(p => p.Id == request.OrderId).FirstOrDefault();
                    var RequestPay = _context.RequestPay.Where(p => p.Id == RequestPayId.RequestPayId).FirstOrDefault();
                    var Product = _context.Products.Where(p => p.Id == items.ProductId);
                    var Address = _context.Addresses.Where(p => p.Id == Order.AddressId).FirstOrDefault();
                    foreach (var product in Product)
                    {
                        OrderDetailsDto.Add(new OrderDetailsDto
                        {
                            Id = items.Id,
                            OrderId = request.OrderId,
                            Count = items.Count,
                            ProductId = items.ProductId,
                            ProductName = product.Title,
                            Price = items.Price,
                            ProductSlug = product.Slug,
                            OrderState = item.OrderState,
                            NameOfRecipient = Address.NameOfRecipient,
                            AddressDetail = Address.AddressDetail,
                            City = Address.City,
                            PostalCode = Address.PostalCode,
                            PhoneNumberForAddress = Address.PhoneNumberForAddress.Value,
                            Province = Address.Province,
                        });
                    }
                }
                return OrderDetailsDto;
            }
            return new List<OrderDetailsDto>();
        }
        else
        {
            return new List<OrderDetailsDto>();
        }

    }
}