namespace Hospital.DAL.Entities
{
    public class DoctorSchedule: AdminConfig
    {
        public int DoctorScheduleId { get; set; }
        public DaysOfWeek DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public bool IsAvailable { get; set; }


        //Navigation Property
        [ForeignKey("Doctor")]
        public string? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
    }
}

