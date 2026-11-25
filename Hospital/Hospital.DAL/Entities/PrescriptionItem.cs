namespace Hospital.DAL.Entities;

public class PrescriptionItem
{
    public int PrescriptionItemId { get; set; }
    public int PrescriptionId { get; set; }
    public int MedicationId { get; set; }
    public string Frequency { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public string? Duration { get; set; }

    public Prescription Prescription { get; set; } = null!;
    public Medication Medication { get; set; } = null!;
}
