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
         public DbSet<Nurse> Nurses { get; set; }
         public DbSet<PrescriptionItem> PrescriptionItems { get; set; }
         public DbSet<Prescription> Prescriptions { get; set; }
         public DbSet<MedicalRecord> MedicalRecords { get; set; }
         public DbSet<Medication> Medications { get; set; }
         public DbSet<Doctor> Doctors { get; set; }
         public DbSet<DoctorSchedule> DoctorSchedule { get; set; }
         public DbSet<Appointment> Appointments { get; set; }
    }
}
