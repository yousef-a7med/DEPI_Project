using Hospital.DAL.Enum;
namespace Hospital.DAL.Entities
{
    public class User
    {
        public string ID { get; set;}
        public  string FullName { get; set; }
        public  string Password { get; set; }
        public Role Role { get; set; }
        public  bool IsActive { get; set; }
        public  string Email { get; set; }


        //Navigation Property
        public List<Patient> Patients { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<Nurse> Nurse { get; set; }

    }
}
