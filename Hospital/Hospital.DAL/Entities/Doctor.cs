
namespace Hospital.DAL.Entities
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string Specialization { get; set; }
        public string LicenseNumber { get; set; }
        public decimal ConsultationFee { get; set; }

        public List<DoctorSchedule> DoctorSchedules { get; set; }
    }
}
