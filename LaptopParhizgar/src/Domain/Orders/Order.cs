using Common.Domain.Bases;

namespace Domain.Orders;
public class Order : BaseEntity
{
    public long UserId { get; private set; }
    public long RequestPayId { get; private set; }
    public long AddressId { get; private set; }
    public OrderState OrderState { get; private set; }
    public ICollection<OrderDetail> OrderDetails { get; set; }

    public Order(long userId, long requestPayId, long addressId)
    {
        UserId = userId;
        RequestPayId = requestPayId;
        AddressId = addressId;
        OrderState = OrderState.Processing;
    }

    public void Canceled()
    {
        OrderState = OrderState.Canceled;
    }

    public void Delivered()
    {
        OrderState = OrderState.Delivered;
    }
}

public enum OrderState
{
    Processing = 0,
    Canceled = 1,
    Delivered = 2
}