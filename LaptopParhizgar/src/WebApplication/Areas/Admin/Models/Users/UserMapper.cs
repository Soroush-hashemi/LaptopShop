using Query.Users.DTOs;

namespace WebApplication.Areas.Admin.Models.Users;
public static class UserMapper
{
    public static UserViewModel MapDto(this UserDto dto)
    {
        return new UserViewModel()
        {
            Id = dto.Id,
            CreationDate = dto.CreationDate,
            UserName = dto.UserName,
            FullName = dto.FullName,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
            Roles = dto.Roles,
        };
    }

    public static List<UserViewModel> MapList(this List<UserDto> ViewModel)
    {
        var Model = new List<UserViewModel>();

        ViewModel.ForEach(c =>
        {
            Model.Add(new UserViewModel
            {
                Id = c.Id,
                CreationDate = c.CreationDate,
                UserName = c.UserName,
                FullName = c.FullName,
                PhoneNumber = c.PhoneNumber,
                Email = c.Email,
                Roles = c.Roles
            });
        });
        return Model;
    }
}