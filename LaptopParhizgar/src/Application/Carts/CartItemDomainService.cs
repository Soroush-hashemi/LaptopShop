using Application.Carts.RemoveItemFromCart;
using Common.Application;
using Domain.Carts.Service;
using MediatR;

namespace Application.Carts;
public class CartItemDomainService : ICartItemDomainService
{
    private readonly IMediator _mediator;
    public CartItemDomainService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> RemoveFromCart(long CartItemId)
    {
        return await _mediator.Send(new RemoveItemFromCartCommand(CartItemId));
    }
}