using Common.Query.Bases;

namespace Query.Addresses.DTO;
public class AddressDto : BaseDto
{
    public long UserId { get; set; }
    public string NameOfRecipient { get; set; }
    public string Province { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string AddressDetail { get; set; }
    public string PhoneNumberForAddress { get; set; }
}