using Common.Domain.Repository;

namespace Domain.User.Repository;
public interface IUserRepository : IBaseRepository<User>
{
    void DeleteUser(User User);
}