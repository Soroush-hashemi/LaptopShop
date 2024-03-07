using Common.Domain.Bases;

namespace Domain.Orders;
public class Order : BaseEntity
{
    public long UserId { get; private set; }
    public long RequestPayId { get; private set; }
    public long AddressId { get; private set; }
    public OrderState OrderState { get; private set; }
    public ICollection<OrderDetail> OrderDetails { get; set; }
}

public enum OrderState
{
    Processing = 0,
    Canceled = 1,
    Delivered = 2
}