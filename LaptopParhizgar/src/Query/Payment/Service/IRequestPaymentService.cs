using Query.Payment.DTO;

namespace Query.Payment.Service;
public interface IPaymentSettingService
{
    RequestPayDto GetRequestPay(Guid guid);
    RequestPayDto GetRequestPayDetail(int RequestPayId);
    RequestPayFilterDto GetRequestPayByFilter(RequestPayFilterParams filterParams);
}