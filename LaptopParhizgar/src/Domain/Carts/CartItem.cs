using Common.Domain.Bases;
using System.ComponentModel.DataAnnotations;

namespace Domain.Carts;
public class CartItem : BaseEntity
{
    public long CartId { get; private set; }
    public long ProductId { get; private set; }
    public int Count { get; private set; }
    public long Price { get; private set; }

    public CartItem(long cartId, long productId, int count, long price)
    {
        CartId = cartId;
        ProductId = productId;
        Count = count;
        Price = price;
    }
}