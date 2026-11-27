using System.ComponentModel.DataAnnotations;

namespace Hospital.DAL.Entities
{
    public class Doctor : AdminConfig
    {
        public string DoctorId { get; set; }
        [Required, MaxLength(100)]
        public string Specialization { get; set; }
        [Required, MaxLength(50)]
        public string LicenseNumber { get; set; }
        public decimal Price { get; set; }

        //Navigation Property
        [ForeignKey("User")]
        public string? UserID { get; set; }
        public User? User { get; set; }

        public List<DoctorSchedule> DoctorSchedules { get; set; }

        public List<Appointment> Appointments { get; set; }

        public List<MedicalRecord> MedicalRecords { get; set; }
    }
}
