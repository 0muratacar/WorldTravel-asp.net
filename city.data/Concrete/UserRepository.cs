using city.data.Abstract;
using city.entity;
using System.Collections.Generic;
using System.Linq;

namespace city.data.Concrete
{
    public class UserRepository : IUser
    {
        public void addUser(User user)
        {
            using (var db = new database())
            {
                db.users.Add(user);
                db.SaveChanges();
            }
        }
        public User findUser(string email, string password)
        {
            List<User> _users;
            using (var db = new database())
            {
                _users = db.users.Where(i => i.eposta == email).ToList();
                foreach(var item in _users)
                {
                    if(item.password == password)
                    {
                        return item;
                    }
                }
                return null;
            }
        }
    }
}