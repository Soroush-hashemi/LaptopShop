using Domain.Addresses;
using Query.Addresses.DTO;

namespace Query.Addresses;
internal static class AddressMapper
{
    public static AddressDto Map(this Address address)
    {
        return new AddressDto()
        {
            Id = address.Id,
            CreationDate = address.CreationDate,
            UserId = address.UserId,
            NameOfRecipient = address.NameOfRecipient,
            Province = address.Province,
            City = address.City,
            PostalCode = address.PostalCode,
            AddressDetail = address.AddressDetail,
            PhoneNumberForAddress = address.PhoneNumberForAddress.Value,
        };
    }

    public static List<AddressDto> MapList(this List<Address> address)
    {
        var model = new List<AddressDto>();

        address.ForEach(address => model.Add(Map(address)));
        return model;
    }
}