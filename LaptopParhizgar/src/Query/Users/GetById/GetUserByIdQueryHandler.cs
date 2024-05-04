using Microsoft.EntityFrameworkCore;
using Query.Users.DTOs;
using Common.Query;
using Infrastructure.Persistence;

namespace Query.Users.GetById;
public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserDto>
{
    private readonly LaptopParhizgerContext _context;
    public GetUserByIdQueryHandler(LaptopParhizgerContext context)
    {
        _context = context;
    }

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(f => f.Id == request.UserId, cancellationToken);
        if (user == null)
            return null;

        var userDto = user.Map();
        return userDto;
    }
}