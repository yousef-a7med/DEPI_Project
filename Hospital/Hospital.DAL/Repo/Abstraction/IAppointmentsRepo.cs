using Hospital.DAL.Entities;

namespace Hospital.DAL.Repo.Abstraction
{
    public interface IAppointmentRepo
    {
        (bool, string?) Create(Appointment appointment);
        (bool, string?) Edit(Appointment newAppointment, string oldAppointmentId);
        (bool, string?) Delete(string appointmentId);
        (bool, string?, Appointment?) GetById(string appointmentId);
        (bool, string?, List<Appointment>?) GetAll(Expression<Func<Appointment, bool>> filter);
        (bool, string?, Appointment?) GetByFilter(Expression<Func<Appointment, bool>> filter);
    }
}