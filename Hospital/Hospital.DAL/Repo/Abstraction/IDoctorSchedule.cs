
namespace Hospital.DAL.Repo.Abstraction
{
    public interface IDoctorSchedule
    {
        (bool, string?) Create(DoctorSchedule doctorschedule);
        (bool, string?) Edite(DoctorSchedule newdoctorschedule, int doctorscheduleId);
        (bool, string?) Delete(int doctorscheduleId);
        (bool, string?, DoctorSchedule?) GetById(int doctorscheduleId);
        (bool, string?, List<DoctorSchedule>?) GetAll();
    }
}
