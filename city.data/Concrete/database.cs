using Microsoft.EntityFrameworkCore;
using city.entity;

namespace city.data.Concrete
{
    public class database : DbContext
    {
        public DbSet<User> users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=cityDB");
        }
    }
}

//dotnet new classlib -o city.entity
//dotnet new classlib -o city.data