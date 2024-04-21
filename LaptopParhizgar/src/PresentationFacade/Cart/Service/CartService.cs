using Infrastructure.Persistence;
using MediatR;
using Query.Cart.DTOs;
using Query.Cart.GetMyCart;

namespace PresentationFacade.Cart.Service;
public class CartService : ICartService
{
    private readonly LaptopParhizgerContext _context;
    private readonly IMediator _mediator;
    public CartService(LaptopParhizgerContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<long> GetTotalPrice(long userId)
    {
        var cart = _context.Carts.Where(u => u.UserId == userId).FirstOrDefault();

        var CartItems = await _mediator.Send(new GetMyCartItemByCartQuery(cart.UserId));
        long SumAmount = CartItems.Sum(p => p.Price * p.Count);

        if (SumAmount == 0)
        {
            return SumAmount;
        }
        if (SumAmount >= 500000)
        {
            return SumAmount;
        }
        if (SumAmount < 500000)
        {
            return SumAmount + 30000;
        }

        return SumAmount;

    }
}