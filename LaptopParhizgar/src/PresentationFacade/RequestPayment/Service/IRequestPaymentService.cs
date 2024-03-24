using PresentationFacade.RequestPayment.Service.DTO;

namespace PresentationFacade.RequestPayment.Service;
public interface IRequestPaymentService
{
    RequestPayDto GetRequestPay(Guid guid);
    RequestPayDto GetRequestPayDetail(int RequestPayId);
    RequestPayFilterDto GetRequestPayByFilter(RequestPayFilterParams filterParams);
}