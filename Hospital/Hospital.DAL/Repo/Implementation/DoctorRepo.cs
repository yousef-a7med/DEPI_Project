
namespace Hospital.DAL.Repo.Implementation
{
    public class DoctorRepo : IDoctorRepo
    {
        private readonly HospitalDbContext Db = new HospitalDbContext();
    
        public (bool, string?) Create(Doctor doctor)

        { 
       try{
            var result = Db.Doctors.Add(doctor);
            Db.SaveChanges();
            if(string.IsNullOrEmpty(result.Entity.DoctorId) )
                    return (true, "Doctor is not created");
                return (false, null);
            }
            catch(Exception ex)

        {
            return (true, ex.Message);
        }
}

        public (bool, string?) Delete(string doctorId)
        {
            try
            {
                var doctor = Db.Doctors.FirstOrDefault(d => d.DoctorId == doctorId);
                if (doctor.DoctorId == null)
                    return (true, "Doctor not found");
                Db.Doctors.Remove(doctor);
                Db.SaveChanges();
                return (false, null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }

        }

        public (bool, string?) Edite(Doctor newdoctor, string olddoctorId)
        {
            try
            {
                var olddoctor = Db.Doctors.Where(d => d.DoctorId == olddoctorId).FirstOrDefault();
                if(olddoctor == null)
                    return (true, "Doctor not found");
                      olddoctor.Specialization = newdoctor.Specialization;
                olddoctor.LicenseNumber = newdoctor.LicenseNumber;
                    olddoctor.Price = newdoctor.Price;
                    Db.SaveChanges();
                         return (false, null);
            }
            catch (Exception ex)

            {
                return (true, ex.Message);
            }
        }

        public (bool, string?, List<Doctor>?) GetAll(Expression<Func<Doctor, bool>> filter)
        {
            try
            {
                var result = Db.Doctors.Where(filter).ToList();
                if(result.Count>0)
                    return (false, null, result);
                return (true, "No Doctor Found", null);
            }
            catch (Exception ex)

            {
                return (true, ex.Message, null);
            }
        }

        public (bool, string?, Doctor?) GetById(string doctorId)
        {
            try
            {
                var doctor = Db.Doctors.FirstOrDefault(d => d.DoctorId == doctorId);
                if (doctor.DoctorId == null)
                    return (true, "Doctor is not Found in DB", null);

                return (false, null, doctor);
            }
            catch (Exception ex)
            {
                return (true, ex.Message, null);
            }
        }
    }
}
