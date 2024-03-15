using Query.PaymentSetting.DTO;

namespace Query.PaymentSetting.Service;
public interface IPaymentSettingService
{
    PaymentSettingDto GetPaymentSetting();
}