using Common.Application;
using Common.Domain.ValueObjects;

namespace Application.Address.Edit;
public class EditAddressesCommand : IBaseCommand
{
    public EditAddressesCommand(long addressId, long userId, string nameOfRecipient, string province,
    string city, string postalCode, string address, PhoneNumber phoneNumberForAddress)
    {
        UserId = userId;
        AddressId = addressId;
        NameOfRecipient = nameOfRecipient;
        Province = province;
        City = city;
        PostalCode = postalCode;
        Address = address;
        PhoneNumberForAddress = phoneNumberForAddress;
    }

    public long UserId { get; set; }
    public long AddressId { get; set; }
    public string NameOfRecipient { get; set; }
    public string Province { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Address { get; set; }
    public PhoneNumber PhoneNumberForAddress { get; set; }
}