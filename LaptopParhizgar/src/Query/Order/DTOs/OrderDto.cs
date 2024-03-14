using Common.Query.Bases;
using Domain.Orders;

namespace Query.Order.DTOs;
public class OrderDto : BaseDto
{
    public long OrderDetailsId { get; set; }
    public OrderState OrderState { get; set; }
    public long RequestPayId { get; set; }
    public long UserId { get; set; }
    public long AddressId { get; set; }
    public string UserName { get; set; }
    public long Price { get; set; }
    public long TotalPrice { get; set; }
    public List<OrderDetailsDto> OrderDetails { get; set; }
}