using Domain.Payment;
using PresentationFacade.RequestPayment.Service.DTO;

namespace PresentationFacade.RequestPayment.Service;
public static class RequestPaymentMapper
{
    public static RequestPayDto MapToDto(this RequestPay requestPay, string Username, string PhoneNumber)
    {
        return new RequestPayDto()
        {
            Id = requestPay.Id,
            IsPay = requestPay.IsPay,
            guid = requestPay.Guid,
            Amount = requestPay.Amount,
            CreationDate = requestPay.CreationDate,
            Username = Username,
            PhoneNumber = PhoneNumber,
            UserId = requestPay.UserId,
        };
    }
}