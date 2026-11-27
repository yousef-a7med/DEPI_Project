using Hospital.DAL.Enum;
namespace Hospital.DAL.Entities
{
    public class Patient : AdminConfig
    {
        public  string ID { get; set; }
        public Gender Gender { get; set; }
        public  BloodType BloodType { get; set; }
        public  DateTime BirthDate { get; set; }
        public  string Allergies { get; set; }


        //Navigation Property
        [ForeignKey("User")]
        public  string? UserID { get; set; }
        public  User? User { get; set; }

        public List<Prescription> Prescriptions { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
