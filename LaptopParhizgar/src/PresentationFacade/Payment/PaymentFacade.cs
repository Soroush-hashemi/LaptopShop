using Application.Payments.PaymentDisable;
using Application.Payments.PaymentEnable;
using Common.Application;
using MediatR;

namespace PresentationFacade.Payment;
public class PaymentFacade : IPaymentFacade
{
    private readonly IMediator _mediator;
    public PaymentFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> PaymentDisable()
    {
        return await _mediator.Send(new PaymentDisableCommand());
    }

    public async Task<OperationResult> PaymentEnable()
    {
        return await _mediator.Send(new PaymentEnableCommand());
    }
}