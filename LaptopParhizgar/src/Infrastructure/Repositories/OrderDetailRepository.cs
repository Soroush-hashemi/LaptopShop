using Domain.Orders;
using Domain.Orders.Repository;
using Infrastructure.Persistence;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories;
public class OrderDetailRepository : BaseRepository<OrderDetail>, IOrderDetailRepository
{
    public OrderDetailRepository(LaptopParhizgerContext context) : base(context)
    {
    }
}