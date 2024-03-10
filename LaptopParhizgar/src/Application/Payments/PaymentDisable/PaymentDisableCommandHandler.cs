using Common.Application;
using Domain.Payment;
using Domain.Payment.Repository;

namespace Application.Payments.PaymentDisable;
public class PaymentDisableCommandHandler : IBaseCommandHandler<PaymentDisableCommand>
{
    private readonly IPaymentSettingsRepository _repository;
    public PaymentDisableCommandHandler(IPaymentSettingsRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(PaymentDisableCommand request, CancellationToken cancellationToken)
    {
        var payment = new PaymentSettings();
        payment.Disable();

        await _repository.Save();
        return OperationResult.Success();
    }
}