using Common.Domain.Bases;

namespace Domain.Orders;
public class OrderDetail : BaseEntity
{
    public long OrderId { get; private set; }
    public long ProductId { get; private set; }
    public long Price { get; private set; }
    public int Count { get; private set; }

    private OrderDetail() 
    {
        
    }

    public OrderDetail(long orderId, long productId, long price, int count)
    {
        OrderId = orderId;
        ProductId = productId;
        Price = price;
        Count = count;
    }
}