using Common.Query;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Query.Users.DTOs;

namespace Query.Users.GetList;
public class GetUserListQueryHandler : IQueryHandler<GetUserListQuery, List<UserDto>>
{
    private readonly LaptopParhizgerContext _context;
    public GetUserListQueryHandler(LaptopParhizgerContext context)
    {
        _context = context;
    }

    public async Task<List<UserDto>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Users.OrderBy(c => c.Id).ToListAsync(cancellationToken);

        return result.MapList();
    }
}