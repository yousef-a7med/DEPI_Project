
namespace Hospital.DAL.Repo.Abstraction
{
    public interface IDoctorScheduleRepo
    {
        (bool, string?) Create(DoctorSchedule doctorschedule);
        (bool, string?) Edite(DoctorSchedule newSchedule, string olddoctorscheduleId);
        (bool, string?) Delete(string doctorscheduleId);
        (bool, string?, DoctorSchedule?) GetById(string doctorscheduleId);
        (bool, string?, List<DoctorSchedule>?) GetAll(Expression<Func<DoctorSchedule, bool>> filter);
    }
}
