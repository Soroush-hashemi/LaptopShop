using Query.Users.DTOs;
using Domain.Users;

namespace Query.Users;
internal static class UserMapper
{
    public static UserDto Map(this User user)
    {
        return new UserDto()
        {
            Id = user.Id,
            CreationDate = user.CreationDate,
            FullName = user.FullName,
            PhoneNumber = user.PhoneNumber,
            Email = user.Email,
            UserName = user.UserName,
            Roles = (DTOs.UserRoleDto)user.Roles,
            Password = user.Password,
        };
    }

    public static List<UserDto> MapList(this List<User> users)
    {
        var model = new List<UserDto>();
        users.ForEach(User =>
        {
            model.Add(new UserDto()
            {
                Id = User.Id,
                CreationDate = User.CreationDate,
                FullName = User.FullName,
                PhoneNumber = User.PhoneNumber,
                Email = User.Email,
                UserName = User.UserName,
                Roles = (DTOs.UserRoleDto)User.Roles,
            });
        });
        return model;
    }
}