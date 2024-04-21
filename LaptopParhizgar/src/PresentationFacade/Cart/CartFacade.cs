using Application.Carts.Add;
using Application.Carts.Decrease;
using Application.Carts.Increase;
using Application.Carts.RemoveItemFromCart;
using Common.Application;
using MediatR;
using Query.Cart.DTOs;
using Query.Cart.GetMyCart;

namespace PresentationFacade.Cart;
public class CartFacade : ICartFacade
{
    private readonly IMediator _mediator;
    public CartFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> Add(long ProductId, long UserId)
    {
        return await _mediator.Send(new AddToCartCommand(ProductId, UserId));
    }

    public async Task<OperationResult> Decrease(DecreaseProductCountCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Increase(IncreaseProductCountCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> RemoveItemFromCart(RemoveItemFromCartCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<List<CartItemDto>> GetMyCart(long UserId)
    {
        return await _mediator.Send(new GetMyCartItemByCartQuery(UserId));
    }

}