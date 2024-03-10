using Common.Application;

namespace Application.Carts.Decrease;
public record DecreaseProductCountCommand(long CartItemId) : IBaseCommand;