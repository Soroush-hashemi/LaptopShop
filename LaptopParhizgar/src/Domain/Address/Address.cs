using Common.Domain.Bases;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Domain.Address;
public class Address : BaseEntity
{
    public long UserId { get; private set; }
    public string NameOfRecipient { get; private set; }
    public string Province { get; private set; }
    public string City { get; private set; }
    public string PostalCode { get; private set; }
    public string Addresses { get; private set; }
    public PhoneNumber PhoneNumberForAddress { get; private set; }

    public Address(long userId, string nameOfRecipient, string province, string city,
        string postalCode, string addresses, PhoneNumber phoneNumberForAddress)
    {
        UserId = userId;
        NameOfRecipient = nameOfRecipient;
        Province = province;
        City = city;
        PostalCode = postalCode;
        Addresses = addresses;
        PhoneNumberForAddress = phoneNumberForAddress;
    }

    public void Edit(string nameOfRecipient, string province, string city,
    string postalCode, string addresses, PhoneNumber phoneNumberForAddress)
    {
        NameOfRecipient = nameOfRecipient;
        Province = province;
        City = city;
        PostalCode = postalCode;
        Addresses = addresses;
        PhoneNumberForAddress = phoneNumberForAddress;
    }

    public void Guard(string nameOfRecipient, string province, string city,
        string postalCode, string addresses, PhoneNumber phoneNumberForAddress)
    {
        if (phoneNumberForAddress.Value.Length > 13)
            throw new NullOrEmptyException("تلفن نامعتبر است");

        if (phoneNumberForAddress.Value.Length < 9)
            throw new NullOrEmptyException("تلفن نامعتبر است");

        NullOrEmptyException.CheckString(nameOfRecipient, nameof(nameOfRecipient));
        NullOrEmptyException.CheckString(province, nameof(province));
        NullOrEmptyException.CheckString(city, nameof(city));
        NullOrEmptyException.CheckString(postalCode, nameof(postalCode));
        NullOrEmptyException.CheckString(addresses, nameof(addresses));
    }
}