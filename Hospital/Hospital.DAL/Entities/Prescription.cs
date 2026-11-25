using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.DAL.Entities
{
    public class Prescription
    {
        public string PrescriptionId { get; set; }
        public DateTime IssuedDate { get; set; }
        public string? Status { get; set; }
        public string? Instructions { get; set; }

        
        public string? MedicalRecordId { get; set; }
        
        [ForeignKey("MedicalRecord")]
        public MedicalRecord? MedicalRecord { get; set; }

        
        public string? PatientId { get; set; }
        
        [ForeignKey("Patient")]
        public Patient? Patient { get; set; }

        
    }
}