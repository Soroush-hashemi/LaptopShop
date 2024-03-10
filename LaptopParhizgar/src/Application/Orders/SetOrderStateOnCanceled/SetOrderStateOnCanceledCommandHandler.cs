using Common.Application;
using Domain.Orders.Repository;

namespace Application.Orders.SetOrderStateOnCanceled;
public class SetOrderStateOnCanceledCommandHandler : IBaseCommandHandler<SetOrderStateOnCanceledCommand>
{
    private readonly IOrderRepository _repository;
    public SetOrderStateOnCanceledCommandHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(SetOrderStateOnCanceledCommand request, CancellationToken cancellationToken)
    {
        var order = await _repository.GetTracking(request.OrderId);
        if (order == null)
            return OperationResult.NotFound();

        order.Canceled();
        await _repository.Save();
        return OperationResult.Success();
    }
}