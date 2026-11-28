
namespace Hospital.DAL.Repo.Implementation
{
    internal class AppointmentRepo : IAppointmentRepo
    {
        private readonly HospitalDbContext Db = new HospitalDbContext();

        (bool, string?) IAppointmentRepo.Create(Appointment appointment)
        {
            try
            {
                var result = Db.Appointments.Add(appointment);
                Db.SaveChanges();

                
                if (result.Entity.ID == 0) 
                    return (true, "Appointment Not Added in DB");

                return (false, null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }

        (bool, string?) IAppointmentRepo.Delete(int appointmentID) 
        {
            try
            {
                var appointment = Db.Appointments.FirstOrDefault(p => p.ID == appointmentID); 

               
                if (appointment == null)
                    return (true, "Appointment is not Found in DB");

                Db.Appointments.Remove(appointment);
                Db.SaveChanges();

                return (false, null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }

        (bool, string?) IAppointmentRepo.Edit(Appointment newAppointment, int oldAppointmentID) 
        {
            try
            {
                var oldAppointment = Db.Appointments.Where(a => a.ID == oldAppointmentID).FirstOrDefault(); 

               
                if (oldAppointment == null)
                    return (true, "There is no appointment in DB");

             
                oldAppointment.AppointmentDate = newAppointment.AppointmentDate; 
                oldAppointment.DoctorId = newAppointment.DoctorId;
                oldAppointment.PatientId = newAppointment.PatientId;

                Db.SaveChanges();

                return (false, null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }

        (bool, string?, List<Appointment>?) IAppointmentRepo.GetAll(Expression<Func<Appointment, bool>> filter)
        {
            try
            {
                var result = Db.Appointments.Where(filter).ToList();
                if (result.Count > 0)
                    return (false, null, result);
                return (true, "There is no Data", null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message, null);
            }
        }

        (bool, string?, List<Appointment>?) IAppointmentRepo.GetAll()
        {
            try
            {
                var result = Db.Appointments.ToList();
                if (result.Count > 0)
                    return (false, null, result);
                return (true, "There is no Data", null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message, null);
            }
        }

        (bool, string?, Appointment?) IAppointmentRepo.GetByID(int appointmentID) 
        {
            try
            {
                var appointment = Db.Appointments.FirstOrDefault(u => u.ID == appointmentID); 
                if (appointment == null)
                    return (true, "Appointment is not Found in DB", null);

                return (false, null, appointment);
            }
            catch (Exception ex)
            {
                return (true, ex.Message, null);
            }
        }
    }
}