namespace Hospital.DAL.Repo.Implementation
{
    internal class PatientRepo : IPatientRepo
    {
        private readonly HospitalDbContext Db = new HospitalDbContext();

        (bool, string?) IPatientRepo.Create(Patient patient)
        {
            try
            {
                var result = Db.Patients.Add(patient);
                Db.SaveChanges();
                if (string.IsNullOrEmpty(result.Entity.ID))
                    return (true, "Patient Not Added in DB");
                return (false, null);

            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }

        (bool, string?) IPatientRepo.Delete(string PatientID)
        {
            try
            {
                var patient = Db.Patients.FirstOrDefault(p => p.ID == PatientID);
                if (patient.ID == null)
                    return (true, "User is not Found in DB");

                Db.Patients.Remove(patient);
                Db.SaveChanges();

                return (false, null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }

        (bool, string?) IPatientRepo.Edit(Patient newPatient, string oldPatientID)
        {
            try
            {
                var oldPatient = Db.Patients.Where(a => a.ID == oldPatientID).FirstOrDefault();
                if (oldPatient != null)
                    return (true, "There is no patient in DB");

                newPatient.BirthDate = oldPatient.BirthDate;
                newPatient.BloodType = oldPatient.BloodType;
                newPatient.Allergies = oldPatient.Allergies;
                newPatient.Gender = oldPatient.Gender;
                Db.SaveChanges();

                return (true, null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }

        (bool, string?, List<Patient>?) IPatientRepo.GetAll(Expression<Func<Patient, bool>> filter)
        {
            try
            {
                var result = Db.Patients.Where(filter).ToList();
                if (result.Count > 0)
                    return (false, null, result);
                return (true, "There is no Data", null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message, null);
            }
        }

        (bool, string?, List<Patient>?) IPatientRepo.GetAll()
        {
            throw new NotImplementedException();
        }

        (bool, string?, Patient?) IPatientRepo.GetByID(string PatientID)
        {
            try
            {
                var patient = Db.Patients.FirstOrDefault(u => u.ID == PatientID);
                if (patient.ID == null)
                    return (true, "patient is not Found in DB", null);

                return (false, null, patient);
            }
            catch (Exception ex)
            {
                return (true, ex.Message, null);
            }
        }
    }
}
