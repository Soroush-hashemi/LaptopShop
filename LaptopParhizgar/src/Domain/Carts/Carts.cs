using Common.Domain.Bases;

namespace Domain.Carts;
public class Carts : BaseEntity
{
    public long UserId { get; private set; }
    public bool IsFinaly { get; private set; }
    public List<CartItem> CartItem { get; private set; }

    public Carts(long userId, bool isFinaly)
    {
        UserId = userId;
        IsFinaly = isFinaly;
        CartItem = new List<CartItem>();
    }
}