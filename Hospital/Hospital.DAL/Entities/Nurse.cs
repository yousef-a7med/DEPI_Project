using System.ComponentModel.DataAnnotations;

namespace Hospital.DAL.Entities
{
    public class Nurse
    {
        public string NurseId { get; set; }
        public string? Shift { get; set; }
        public string? Department { get; set; }
        public string? LicenseNumber { get; set; }

    }
}