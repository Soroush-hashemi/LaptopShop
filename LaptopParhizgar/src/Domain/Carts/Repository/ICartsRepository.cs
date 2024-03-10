using Common.Domain.Repository;

namespace Domain.Carts.Repository;
public interface ICartsRepository : IBaseRepository<Cart>
{
    public Cart GetByUserId(long UserId); // Where(p => p.UserId == UserId && p.IsFinaly == false).FirstOrDefault();
}