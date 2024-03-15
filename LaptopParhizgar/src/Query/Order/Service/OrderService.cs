using Infrastructure.Persistence;

namespace Query.Order.Service;
public class OrderService : IOrderService
{
    private LaptopParhizgerContext _context;
    public OrderService(LaptopParhizgerContext context)
    {
        _context = context;
    }

    public long TotalPrice(long OrderId)
    {
        var RequestPayId = _context.Orders.Where(p => p.Id == OrderId).FirstOrDefault();
        var RequestPay = _context.RequestPay.Where(p => p.Id == RequestPayId.RequestPayId).FirstOrDefault();
        int TotalPrice = RequestPay.Amount;
        return TotalPrice;
    }
}