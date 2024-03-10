using Common.Application;

namespace Application.Orders.Add;
public class AddOrderCommand : IBaseCommand
{
    public long CartId { get; set; }
    public long RequestPayId { get; set; }
    public long UserId { get; set; }
    public long TotalPrice { get; set; }
    public long AddressId { get; set; }

    public AddOrderCommand(long cartId, long requestPayId, long userId, long totalPrice, long addressId)
    {
        CartId = cartId;
        RequestPayId = requestPayId;
        UserId = userId;
        TotalPrice = totalPrice;
        AddressId = addressId;
    }
}