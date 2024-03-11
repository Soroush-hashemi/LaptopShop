using Domain.Carts;
using Domain.Carts.Repository;
using Infrastructure.Persistence;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories;
public class CartsRepository : BaseRepository<Cart>, ICartsRepository
{
    public CartsRepository(LaptopParhizgerContext context) : base(context)
    {
    }

    public Cart GetByUserId(long UserId)
    {
        return _context.Carts.FirstOrDefault(c => c.UserId == UserId);
    }
}