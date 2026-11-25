using Microsoft.EntityFrameworkCore;
namespace Hospital.DAL.DataBase
{
    public class HospitalDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=yousefa7med;Database=Hospital_Dev;Trusted_Connection=True;TrustServerCertificate=True;");
        }
         public DbSet<User> Users{ get; set; }
        public DbSet<Patient> Patients { get; set; }
    }
}
