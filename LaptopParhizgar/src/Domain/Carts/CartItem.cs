using Common.Domain.Bases;
using Common.Domain.Exceptions;
using Domain.Carts.Service;

namespace Domain.Carts;
public class CartItem : BaseEntity
{
    public long CartId { get; private set; }
    public long ProductId { get; private set; }
    public int Count { get; private set; }
    public long Price { get; set; }

    private CartItem()
    {

    }

    public CartItem(long cartId, long productId, int count, long price)
    {
        CartId = cartId;
        ProductId = productId;
        Count = count;
        Price = price;
    }

    public void Increase()
    {
        Count++;
        if (Count >= 4)
            throw new ProductIsNotEnoughException("محصول مورد نظر کافی نمیباشد لطفا برای هماهنگی تماس بگیرید");
    }

    public void Decrease(long cartItemId, ICartItemDomainService domainService)
    {
        if (Count <= 1)
            domainService.RemoveFromCart(cartItemId);
        Count--;
    }
}