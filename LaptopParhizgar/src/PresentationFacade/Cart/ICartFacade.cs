using Application.Carts.Add;
using Application.Carts.Decrease;
using Application.Carts.Increase;
using Application.Carts.RemoveItemFromCart;
using Common.Application;
using Query.Cart.DTOs;

namespace PresentationFacade.Cart;
public interface ICartFacade
{
    Task<OperationResult> Add(long ProductId, long UserId);
    Task<OperationResult> Decrease(DecreaseProductCountCommand command);
    Task<OperationResult> Increase(IncreaseProductCountCommand command);
    Task<OperationResult> RemoveItemFromCart(RemoveItemFromCartCommand command);

    Task<List<CartItemDto>> GetMyCart(long UserId);
}
