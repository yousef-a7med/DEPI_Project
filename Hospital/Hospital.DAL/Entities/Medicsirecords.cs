using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.DAL.Entities;

public class MedicalRecord
{
    public int MedicalRecordId { get; set; }
    public int PatientId { get; set; }
    public int AppointmentId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string? TreatmentPlan { get; set; }
    public string? Diagnosis { get; set; }
    public string? Symptoms { get; set; }

    public Patient Patient { get; set; } = null!;
    public Appointment Appointment { get; set; } = null!;
    public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
