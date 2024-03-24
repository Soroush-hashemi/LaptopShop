using Common.Application;
using PresentationFacade.PaymentSetting.Service.DTO;

namespace PresentationFacade.PaymentSetting.Service;
public interface IPaymentSettingService
{
    PaymentSettingDto GetPaymentSetting();
    OperationResult SetPaymentToDisable();
    OperationResult SetPaymentToEnable();
}