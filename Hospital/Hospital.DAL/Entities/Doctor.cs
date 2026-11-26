
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.DAL.Entities
{
    public class Doctor
    {
        public string DoctorId { get; set; }
        public string Specialization { get; set; }
        public string LicenseNumber { get; set; }
        public decimal ConsultationFee { get; set; }

        //Navigation Property
        [ForeignKey("User")]
        public string UserID { get; set; }
        public User User { get; set; }
        public List<DoctorSchedule> DoctorSchedules { get; set; }
    }
}
