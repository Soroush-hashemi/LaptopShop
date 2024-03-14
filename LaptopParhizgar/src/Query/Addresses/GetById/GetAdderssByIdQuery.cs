using Common.Query;
using Query.Addresses.DTO;

namespace Query.Addresses.GetById;
public record GetAdderssByIdQuery(long addressId) : IQuery<AddressDto>;