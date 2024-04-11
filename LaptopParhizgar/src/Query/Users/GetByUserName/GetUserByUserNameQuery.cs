using Common.Query;
using Query.Users.DTOs;

namespace Query.Users.GetByUserName;

public record GetUserByUserNameQuery(string UserName) : IQuery<UserDto?>;