namespace Hospital.DAL.Entities
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }
        public DateTime IssuedDate { get; set; }
        public string? Status { get; set; }
        public string? Instructions { get; set; }


        //Navigation Property
        [ForeignKey("MedicalRecord")]
        public int? MedicalRecordId { get; set; }
        public MedicalRecord? MedicalRecord { get; set; }

        [ForeignKey("Patient")]
        public string? PatientId { get; set; }
        public Patient? Patient { get; set; }

        public List<PrescriptionItem> PrescriptionItems { get; set; }
    }
}