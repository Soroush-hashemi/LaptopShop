using Common.Application;
using Domain.Payment;
using Domain.Payment.Repository;

namespace Application.Payments.PaymentEnable;
public class PaymentEnableCommandHandler : IBaseCommandHandler<PaymentEnableCommand>
{
    private readonly IPaymentSettingsRepository _repository;
    public PaymentEnableCommandHandler(IPaymentSettingsRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(PaymentEnableCommand request, CancellationToken cancellationToken)
    {
        var payment = new PaymentSettings();
        payment.Enable();

        await _repository.Save();
        return OperationResult.Success();
    }
}