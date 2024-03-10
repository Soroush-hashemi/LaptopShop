using Common.Domain.Bases;

namespace Domain.Carts;
public class Cart : BaseEntity
{
    public long UserId { get; private set; }
    public bool IsFinaly { get; private set; }

    public Cart(long userId, bool isFinaly)
    {
        UserId = userId;
        IsFinaly = isFinaly;
    }

    public void Finaly()
    {
        IsFinaly = true;
    }
}