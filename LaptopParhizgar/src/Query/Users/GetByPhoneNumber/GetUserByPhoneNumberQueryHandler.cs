using Common.Query;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Query.Users.DTOs;
namespace Query.Users.GetByPhoneNumber;

public class GetUserByPhoneNumberQueryHandler : IQueryHandler<GetUserByPhoneNumberQuery, UserDto?>
{
    private readonly LaptopParhizgerContext _context;

    public GetUserByPhoneNumberQueryHandler(LaptopParhizgerContext context)
    {
        _context = context;
    }

    public async Task<UserDto?> Handle(GetUserByPhoneNumberQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(f => f.PhoneNumber.Value == request.PhoneNumber, cancellationToken);

        if (user == null)
            return null;

        return user.Map();
    }
}