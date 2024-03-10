using Common.Application;

namespace Application.Carts.Increase;
public record IncreaseProductCountCommand(long CartItemId) : IBaseCommand;