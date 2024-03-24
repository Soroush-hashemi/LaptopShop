using Common.Application;
using Infrastructure.Persistence;
using PresentationFacade.PaymentSetting.Service.DTO;

namespace PresentationFacade.PaymentSetting.Service;
public class PaymentSettingService : IPaymentSettingService
{
    private LaptopParhizgerContext _context;
    public PaymentSettingService(LaptopParhizgerContext context)
    {
        _context = context;
    }

    public PaymentSettingDto GetPaymentSetting()
    {
        var PaymentSetting = _context.PaymentSettings.FirstOrDefault();
        var Payment = new PaymentSettingDto()
        {
            PaymentStatus = PaymentSetting.PaymentStatus,
        };
        return Payment;
    }

    public OperationResult SetPaymentToDisable()
    {
        var payment = _context.PaymentSettings.FirstOrDefault();
        payment.Disable();

        _context.PaymentSettings.Update(payment);
        _context.SaveChanges();
        return OperationResult.Success();
    }

    public OperationResult SetPaymentToEnable()
    {
        var payment = _context.PaymentSettings.FirstOrDefault();
        payment.Enable();

        _context.PaymentSettings.Update(payment);
        _context.SaveChanges();
        return OperationResult.Success();
    }
}