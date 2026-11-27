using Hospital.DAL.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace Hospital.DAL.Entities
{
    public class Patient
    {
        public  string ID { get; set; }
        public Gender Gender { get; set; }
        public  BloodType BloodType { get; set; }
        public  DateTime BirthDate { get; set; }
        public  string Allergies { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public string? ModifirrUser { get; set; }
        public bool IsDeleted { get; set; }
        public string? DeleterUser { get; set; }
        public DateTime? DeletedOn { get; set; }

        //Navigation Property
        [ForeignKey("User")]
        public  string UserID { get; set; }
        public  User User { get; set; }

        public List<Prescription> Prescriptions { get; set; }
    }
}
