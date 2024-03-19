using Application.Carts.Add;
using Application.Carts.Decrease;
using Application.Carts.Increase;
using Application.Carts.RemoveItemFromCart;
using Common.Application;
using Query.Cart.DTOs;
using Query.Cart.GetMyCart;

namespace PresentationFacade.Cart;
public interface ICartFacade
{
    Task<OperationResult> Add(AddToCartCommand command);
    Task<OperationResult> Decrease(DecreaseProductCountCommand command);
    Task<OperationResult> Increase(IncreaseProductCountCommand command);
    Task<OperationResult> RemoveItemFromCart(RemoveItemFromCartCommand command);

    Task<List<CartItemDto>> GetMyCart(GetMyCartItemByCartQuery query);
}
