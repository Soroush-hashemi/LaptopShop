using Common.Application;

namespace Application.Orders.SetOrderStateOnCanceled;
public record SetOrderStateOnCanceledCommand(long OrderId) : IBaseCommand;