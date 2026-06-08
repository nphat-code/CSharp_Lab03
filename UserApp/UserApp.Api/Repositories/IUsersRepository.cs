using UserApp.Api.Models;

namespace UserApp.Api.Repositories;

public interface IUsersRepository
{
    IList<User> GetAll();
    User? GetById(long id);
    User Add(User user);
}