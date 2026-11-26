using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.DAL.Entities;

public class PrescriptionItem
{
    public int PrescriptionItemId { get; set; }
    public string Frequency { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public string? Duration { get; set; }

    //Navigation Property
    [ForeignKey("Prescription")]
    public int PrescriptionId { get; set; }
    public Prescription Prescription { get; set; } = null!;

    [ForeignKey("Medication")]
    public int? MedicationId { get; set; }
    public Medication Medication { get; set; }
    
}
