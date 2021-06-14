using Microsoft.EntityFrameworkCore;
using city.entity;

namespace city.data.Concrete
{
    public class database : DbContext
    {
        // Kullanýcý bilgilerini tutan tablo yapýsý
        public DbSet<User> users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Azure platformunda oluþturulan sql server baðlantý dizesi
            optionsBuilder.UseSqlServer("Server=tcp:worldtravel.database.windows.net,1433;Initial Catalog=worldtravelDB;Persist Security Info=False;User ID=worldtravel;Password='Mehmetnurmurat1';MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}

//dotnet new classlib -o city.entity
//dotnet new classlib -o city.data