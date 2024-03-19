using PresentationFacade.Payment.Service.DTO;

namespace PresentationFacade.Payment.Service;
public interface IPaymentSettingService
{
    RequestPayDto GetRequestPay(Guid guid);
    RequestPayDto GetRequestPayDetail(int RequestPayId);
    RequestPayFilterDto GetRequestPayByFilter(RequestPayFilterParams filterParams);
}