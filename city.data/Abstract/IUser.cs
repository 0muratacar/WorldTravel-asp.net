using city.entity;

namespace city.data.Abstract
{
    public interface IUser
    {
         void addUser(User user);

        User findUser(string email, string password);
    }
}