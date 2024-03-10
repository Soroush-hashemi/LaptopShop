using Common.Application;

namespace Application.Carts.Add;
public class AddToCartCommand : IBaseCommand
{
    public long ProductId { get; set; }
    public long UserId { get; set; }
}