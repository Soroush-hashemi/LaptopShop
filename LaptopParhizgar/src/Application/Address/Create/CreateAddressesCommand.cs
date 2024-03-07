using Common.Application;
using Common.Domain.ValueObjects;

namespace Application.Address.Create;
public class CreateAddressesCommand : IBaseCommand
{
    public CreateAddressesCommand(long userId, string nameOfRecipient, string province,
    string city, string postalCode, string address, PhoneNumber phoneNumberForAddress)
    {
        UserId = userId;
        NameOfRecipient = nameOfRecipient;
        Province = province;
        City = city;
        PostalCode = postalCode;
        Address = address;
        PhoneNumberForAddress = phoneNumberForAddress;
    }

    public long UserId { get; set; }
    public string NameOfRecipient { get; set; }
    public string Province { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Address { get; set; }
    public PhoneNumber PhoneNumberForAddress { get; set; }
}