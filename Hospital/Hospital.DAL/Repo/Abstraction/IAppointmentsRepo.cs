namespace Hospital.DAL.Repo.Abstraction
{
    public interface IAppointmentRepo
    {
        (bool, string?) Create(Appointment appointment);
        (bool, string?) Edit(Appointment newAppointment, int oldAppointmentId);
        (bool, string?) Delete(int appointmentId);
        (bool, string?, Appointment?) GetById(int appointmentId);
        (bool, string?, List<Appointment>?) GetAll(Expression<Func<Appointment, bool>> filter);
        (bool, string?, Appointment?) GetByFilter(Expression<Func<Appointment, bool>> filter);
    }
}