namespace Hospital.DAL.Entities
{
    public class Nurse : AdminConfig
    {
        public string NurseId { get; set; }
        public string? Shift { get; set; }
        public string? Department { get; set; }
        public string? LicenseNumber { get; set; }



        //Navigation Property
        [ForeignKey("User")]
        public string? UserID { get; set; }
        public User? User { get; set; }

        public List<MedicalRecord> MedicalRecords { get; set; }

        public List<Appointment> Appointments { get; set; }

    }
}