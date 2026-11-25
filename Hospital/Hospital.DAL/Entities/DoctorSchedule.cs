using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.DAL.Entities
{
    public class DoctorSchedule
    {
        public int DoctorScheduleId { get; set; }
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public DaysOfWeek DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public bool IsAvailable { get; set; }

        public Doctor? Doctor { get; set; }
    }
}
