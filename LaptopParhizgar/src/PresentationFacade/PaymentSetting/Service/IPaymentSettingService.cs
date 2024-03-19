using PresentationFacade.PaymentSetting.Service.DTO;

namespace PresentationFacade.PaymentSetting.Service;
public interface IPaymentSettingService
{
    PaymentSettingDto GetPaymentSetting();
}