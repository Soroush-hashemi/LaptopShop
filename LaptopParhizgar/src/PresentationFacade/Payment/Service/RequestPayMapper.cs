using Domain.Payment;
using PresentationFacade.Payment.Service.DTO;

namespace PresentationFacade.Payment.Service;
internal static class RequestPayMapper
{
    public static RequestPayDto MapToDto(RequestPay requestPay, string Username, string PhoneNumber)
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