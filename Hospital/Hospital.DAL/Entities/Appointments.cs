namespace Hospital.DAL.Entities
{
    public class Appointment : AdminConfig
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime EndTime { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Pending";
        public string? Notes { get; set; }

        //Navigation Property
        [ForeignKey("Patient")]
        public string? PatientId { get; set; }
        public Patient? Patient { get; set; }

        [ForeignKey("Doctor")]
        public string? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }


        public MedicalRecord? MedicalRecord { get; set; }

        [ForeignKey("Nurse")]
        public string? NurseId { get; set; }
        public Nurse? Nurse { get; set; }
    }
}
