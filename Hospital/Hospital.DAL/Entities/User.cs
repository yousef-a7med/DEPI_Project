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

        public  DateTime CreatedOn { get; set; }= DateTime.Now;
        public  string? CreatorUser { get; set; }
        public  DateTime? ModifiedOn { get; set; }
        public string? ModifirrUser { get; set; }
        public  bool IsDeleted { get; set; }
        public string? DeleterUser { get; set; }
        public DateTime? DeletedOn { get; set; }

        //Navigation Property
        public List<Patient> Patients { get; set; }
        public List<Doctor> Doctors { get; set; }


    }
}
