using Common.Query;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Query.Addresses.DTO;

namespace Query.Addresses.GetById;
public class GetAdderssByIdQueryHandler : IQueryHandler<GetAdderssByIdQuery, AddressDto>
{
    private LaptopParhizgerContext _context;
    public GetAdderssByIdQueryHandler(LaptopParhizgerContext context)
    {
        _context = context;
    }

    public async Task<AddressDto> Handle(GetAdderssByIdQuery request, CancellationToken cancellationToken)
    {
        var address = await _context.Addresses.FirstOrDefaultAsync(c => c.Id == request.addressId, cancellationToken);
        if (address == null)
            return null;

        return address.Map();
    }
}