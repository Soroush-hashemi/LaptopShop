using Common.Query;
using Query.Users.DTOs;

namespace Query.Users.GetList;
public record GetUserListQuery : IQuery<List<UserDto>>;