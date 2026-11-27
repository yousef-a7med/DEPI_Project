namespace Hospital.DAL.Entities
{
    public class Medication
    {
        public int MedicationId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int StockQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime? ExpiryDate { get; set; }


        //Navigation Property
        public List<PrescriptionItem> PrescriptionItems { get; set; }
    }
}