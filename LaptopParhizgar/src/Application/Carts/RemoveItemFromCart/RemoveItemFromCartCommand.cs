using Common.Application;

namespace Application.Carts.RemoveItemFromCart;
public record RemoveItemFromCartCommand(long CartItemId) : IBaseCommand;