using Common.Domain.Bases;

namespace Domain.Orders;
public class OrderDetail : BaseEntity
{
    public long OrderId { get; private set; }
    public long ProductId { get; private set; }
    public long Price { get; private set; }
    public int Count { get; private set; }

    public OrderDetail(int orderId, int productId, int price, int count)
    {
        OrderId = orderId;
        ProductId = productId;
        Price = price;
        Count = count;
    }


}