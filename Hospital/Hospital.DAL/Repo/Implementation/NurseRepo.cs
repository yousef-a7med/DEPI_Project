namespace Hospital.DAL.Repo.Implementation
{
    public class NurseRepo : INurseRepo
    {
        private readonly HospitalDbContext Db = new HospitalDbContext();

        public (bool, string?) Create(Nurse nurse)
        {
            try
            {
                var result = Db.Nurses.Add(nurse);
                Db.SaveChanges();
                if (string.IsNullOrEmpty(result.Entity.NurseId))
                    return (true, "Nurse not added in DB :(");

                return (false, null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }

        public (bool, string?) Edit(Nurse newNurse, string oldNurseId)
        {
            try
            {
                var oldNurse = Db.Nurses.Where(a => a.NurseId == oldNurseId).FirstOrDefault();
                if (oldNurse == null)
                    return (true, "There is no Nurse in Db :(");

                oldNurse.Shift = newNurse.Shift;
                oldNurse.Department = newNurse.Department;
                oldNurse.LicenseNumber = newNurse.LicenseNumber;

                Db.SaveChanges();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }

        public (bool, string?, List<Nurse>?) GetAll(Expression<Func<Nurse, bool>>? filter)
        {
            try
            {
                var result = Db.Nurses.Where(filter).ToList();
                    
                if (result.Count > 0)
                    return (false, null, result);

                return (true, "There is no Data :(", null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message, null);
            }
        }

        public (bool, string?, Nurse?) GetById(string nurseId)
        {
            try
            {
                var nurse = Db.Nurses.Where(a => a.NurseId == nurseId).FirstOrDefault();
                if (nurse == null)
                    return (true, "There is no Nurse in Db :(", null);

                return (false, null, nurse);
            }
            catch (Exception ex)
            {
                return (true, ex.Message, null);
            }
        }

        public (bool, string?) Delete(string nurseId)
        {
            try
            {
                var nurse = Db.Nurses.Where(a => a.NurseId == nurseId).FirstOrDefault();
                if (nurse == null)
                    return (true, "There is no Nurse in Db :(");

                Db.Nurses.Remove(nurse);
                Db.SaveChanges();
                return (false, null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }
    }
}