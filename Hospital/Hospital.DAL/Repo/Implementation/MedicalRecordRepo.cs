
namespace Hospital.DAL.Repo.Implementation
{
    internal class MedicalRecordRepo : IMedicalRecordRepo
    {
        private readonly HospitalDbContext Db = new HospitalDbContext();

        (bool, string?) IMedicalRecordRepo.Create(Medicsirecords medicalRecord)
        {
            try
            {
                var result = Db.Medicsirecords.Add(medicalRecord);
                Db.SaveChanges();

                if (result.Entity.ID == 0) 
                    return (true, "Medical Record Not Added in DB");

                return (false, null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }

        (bool, string?) IMedicalRecordRepo.Delete(int recordID) 
        {
            try
            {
                var record = Db.Medicsirecords.FirstOrDefault(p => p.ID == recordID); 

                if (record == null)
                    return (true, "Medical Record is not Found in DB");

                Db.Medicsirecords.Remove(record);
                Db.SaveChanges();

                return (false, null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }

        (bool, string?) IMedicalRecordRepo.Edit(Medicsirecords newRecord, int oldRecordID) 
        {
            try
            {
                var oldRecord = Db.Medicsirecords.Where(a => a.ID == oldRecordID).FirstOrDefault(); 

                if (oldRecord == null)
                    return (true, "There is no medical record in DB");

                
                oldRecord.Diagnosis = newRecord.Diagnosis; 
                oldRecord.TreatmentPlan = newRecord.TreatmentPlan;

                Db.SaveChanges();

                return (false, null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }

        (bool, string?, List<Medicsirecords>?) IMedicalRecordRepo.GetAll(Expression<Func<Medicsirecords, bool>> filter)
        {
            try
            {
                var result = Db.Medicsirecords.Where(filter).ToList();
                if (result.Count > 0)
                    return (false, null, result);
                return (true, "There is no Data", null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message, null);
            }
        }

        (bool, string?, List<Medicsirecords>?) IMedicalRecordRepo.GetAll()
        {
            try
            {
                var result = Db.Medicsirecords.ToList();
                if (result.Count > 0)
                    return (false, null, result);
                return (true, "There is no Data", null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message, null);
            }
        }

        (bool, string?, Medicsirecords?) IMedicalRecordRepo.GetByID(int recordID) 
        {
            try
            {
                var record = Db.Medicsirecords.FirstOrDefault(u => u.ID == recordID); 
                if (record == null)
                    return (true, "Medical Record is not Found in DB", null);

                return (false, null, record);
            }
            catch (Exception ex)
            {
                return (true, ex.Message, null);
            }
        }
    }
}
