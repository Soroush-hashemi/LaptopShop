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
            PaymentStatus = PaymentSetting.PaymentSetting,
        };
        return Payment;
    }
}