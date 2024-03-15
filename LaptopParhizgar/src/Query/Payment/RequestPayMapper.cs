using Domain.Payment;
using Query.Payment.DTO;

namespace Query.Payment;
public static class RequestPayMapper
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