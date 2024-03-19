using Common.Application;

namespace PresentationFacade.Payment;
public interface IPaymentFacade 
{
    Task<OperationResult> PaymentDisable();
    Task<OperationResult> PaymentEnable();
}