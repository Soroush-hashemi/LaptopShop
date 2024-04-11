using Common.Query;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Query.Users.DTOs;

namespace Query.Users.GetByUserName;

public class GetUserByUserNameQueryHandler : IQueryHandler<GetUserByUserNameQuery, UserDto?>
{
    private readonly LaptopParhizgerContext _context;
    public GetUserByUserNameQueryHandler(LaptopParhizgerContext context)
    {
        _context = context;
    }
    
    public async Task<UserDto?> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(f => f.UserName == request.UserName, cancellationToken);

        if (user == null)
            return null;

        return user.Map();
    }
}