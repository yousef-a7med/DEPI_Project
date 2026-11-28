
namespace Hospital.DAL.Repo.Abstraction
{
    public interface IDoctorScheduleRepo
    {
        (bool, string?) Create(DoctorSchedule schedule);
        (bool, string?) Edite(DoctorSchedule newSchedule, string oldScheduleId);
        (bool, string?) Delete(string scheduleId);
        (bool, string?, DoctorSchedule?) GetById(string scheduleId);
        (bool, string?, List<DoctorSchedule>?) GetAll(Expression<Func<DoctorSchedule, bool>> filter);
    }
}
