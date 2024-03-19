using Common.Query;
using Query.Users.DTOs;

namespace Query.Users.GetByPhoneNumber;

public record GetUserByPhoneNumberQuery(string PhoneNumber) : IQuery<UserDto>;