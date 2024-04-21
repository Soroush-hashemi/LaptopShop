using Common.Application;

namespace Application.Carts.Add;
public class AddToCartCommand : IBaseCommand
{
    public AddToCartCommand(long productId, long userId)
    {
        ProductId = productId;
        UserId = userId;
    }

    public long ProductId { get; set; }
    public long UserId { get; set; }
}