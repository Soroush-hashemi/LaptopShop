using Common.Application;
using Domain.Orders.Repository;

namespace Application.Orders.SetOrderStateOnDelivered;
public class SetOrderStateOnDeliveredCommandHandler : IBaseCommandHandler<SetOrderStateOnDeliveredCommand>
{
    private readonly IOrderRepository _repository;
    public SetOrderStateOnDeliveredCommandHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(SetOrderStateOnDeliveredCommand request, CancellationToken cancellationToken)
    {
        var order = await _repository.GetTracking(request.OrderId);
        if (order == null)
            return OperationResult.NotFound();

        order.Delivered();
        await _repository.Save();
        return OperationResult.Success();
    }
}