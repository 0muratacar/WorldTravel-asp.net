using city.data.Abstract;
using city.entity;

namespace city.data.Concrete
{
    public class UserRepository : IUser
    {
        public void addUser(User user)
        {
            using (var db=new database()){
                db.users.Add(user);
                db.SaveChanges();
            }
        }
    }
}