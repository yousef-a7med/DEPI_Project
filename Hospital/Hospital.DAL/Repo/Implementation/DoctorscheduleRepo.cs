
namespace Hospital.DAL.Repo.Implementation
{
    public class DoctorscheduleRepo : IDoctorScheduleRepo
    {
        private readonly HospitalDbContext Db = new HospitalDbContext();
        public (bool, string?) Create(DoctorSchedule schedule)
        {
            try
            {
                var result = Db.DoctorSchedule.Add(schedule );
                Db.SaveChanges();
                if (string.IsNullOrEmpty(result.Entity.DoctorId))
                    return (true, "Doctor Schedule   is not created");
                return (false, null);
            }
            catch (Exception ex)

            {
                return (true, ex.Message);
            }
        }

        public (bool, string?) Delete(string scheduleId)
        {
            try
            {
                var schedule = Db.DoctorSchedule.FirstOrDefault(s => s.DoctorId == scheduleId);
                if (schedule.DoctorId == null)
                    return (true, "Doctor Schedule not found");
                Db.DoctorSchedule.Remove(schedule);
                Db.SaveChanges();
                return (false, null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }

        public (bool, string?) Edite(DoctorSchedule newSchedule, string oldScheduleId)
        {
            try
            {
                var oldSchedule = Db.DoctorSchedule.Where(s => s.DoctorId == oldScheduleId).FirstOrDefault();
                if (oldSchedule == null)
                    return (true, "Doctor Schedule not found");
                oldSchedule.DayOfWeek = newSchedule.DayOfWeek;
                oldSchedule.StartTime = newSchedule.StartTime;
                oldSchedule.EndTime = newSchedule.EndTime;
                oldSchedule.IsAvailable = newSchedule.IsAvailable;
                Db.SaveChanges();
                return (false, null);
            }
            catch (Exception ex)

            {
                return (true, ex.Message);
            }
        }
        

        public (bool, string?, List<DoctorSchedule>?) GetAll(Expression<Func<DoctorSchedule, bool>> filter)
        {

            try
            {
                var result = Db.DoctorSchedule.Where(filter).ToList();
                if (result.Count > 0)
                    return (false, null, result);
                return (true, "No DoctorSchedule Found", null);
            }
            catch (Exception ex)

            {
                return (true, ex.Message, null);
            }
        }

        public (bool, string?, DoctorSchedule?) GetById(string scheduleId)
        {
            try
            {
                var doctorSchedule = Db.DoctorSchedule.FirstOrDefault(s => s.DoctorId == scheduleId);
                if (doctorSchedule.DoctorId == null)
                    return (true, "DoctorSchedule not found", null);
                return (false, null, doctorSchedule);
            }
            catch (Exception ex)
            {
                return (true, ex.Message, null);
            }
        }
    }
}
