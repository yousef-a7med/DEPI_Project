namespace Hospital.DAL.Entities
{
    public class MedicalRecord : AdminConfig
    {
        public int MedicalRecordId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? TreatmentPlan { get; set; }
        public string? Diagnosis { get; set; }
        public string? Symptoms { get; set; }


        //Navigation Property
        [ForeignKey("Appointment")]
        public int? AppointmentId { get; set; }
        public Appointment? Appointment { get; set; }


        [ForeignKey("Nurse")]
        public string? NurseId { get; set; }
        public Nurse? Nurse { get; set; }

        [ForeignKey("Doctor")]
        public string? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        public List<Prescription> Prescriptions { get; set; }
    }
}
