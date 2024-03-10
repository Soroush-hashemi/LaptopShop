using Common.Domain.Repository;

namespace Domain.Users.Repository;
public interface IUserRepository : IBaseRepository<User>
{
    void DeleteUser(User User);
}