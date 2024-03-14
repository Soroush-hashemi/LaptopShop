using Common.Application;
using Common.Domain.ValueObjects;

namespace Application.Addresses.Create;
public class CreateAddressCommand : IBaseCommand
{
    public CreateAddressCommand(long userId, string nameOfRecipient, string province,
    string city, string postalCode, string address, PhoneNumber phoneNumberForAddress)
    {
        UserId = userId;
        NameOfRecipient = nameOfRecipient;
        Province = province;
        City = city;
        PostalCode = postalCode;
        AddressDetail = address;
        PhoneNumberForAddress = phoneNumberForAddress;
    }

    public long UserId { get; set; }
    public string NameOfRecipient { get; set; }
    public string Province { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string AddressDetail { get; set; }
    public PhoneNumber PhoneNumberForAddress { get; set; }
}