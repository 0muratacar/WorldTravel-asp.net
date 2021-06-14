using city.data.Abstract;
using city.entity;
using System.Collections.Generic;
using System.Linq;

namespace city.data.Concrete
{
    // IUserden implement alýnýyor.
    public class UserRepository : IUser
    {
        public void addUser(User user)
        {
            // Entity framework yardýmý ile veritabanýna baðlanýp user tablosuna gelen user nesnesini ekliyoruz.
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
                // Veritabaný içerisindeki e postaya göre linq yapýsý ile filtreleme yaparak gelen veriler içinde doðru parolasý olan kullanýcý geri döndürülür.
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