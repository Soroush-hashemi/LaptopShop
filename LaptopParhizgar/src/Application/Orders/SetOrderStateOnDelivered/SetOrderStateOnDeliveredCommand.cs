using Common.Application;

namespace Application.Orders.SetOrderStateOnDelivered;
public record SetOrderStateOnDeliveredCommand(long OrderId) : IBaseCommand;