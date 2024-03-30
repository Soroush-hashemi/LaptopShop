using PresentationFacade.RequestPayment.Service.DTO;

namespace PresentationFacade.RequestPayment.Service;
public interface IRequestPaymentService
{
    RequestPayDto GetRequestPay(Guid guid);
    RequestPayDto GetRequestPayDetail(long RequestPayId);
    RequestPayFilterDto GetRequestPayByFilter(RequestPayFilterParams filterParams);
}