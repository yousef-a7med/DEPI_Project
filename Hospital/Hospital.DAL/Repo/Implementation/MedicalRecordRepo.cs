
namespace Hospital.DAL.Repo.Implementation
{
    internal class MedicalRecordRepo : IMedicalRecordRepo
    {
        private readonly HospitalDbContext Db = new HospitalDbContext();

        (bool, string?) IMedicalRecordRepo.Create(MedicalRecord medicalRecord)
        {
            try
            {
                var result = Db.MedicalRecords.Add(medicalRecord);
                Db.SaveChanges();

                if (result.Entity.MedicalRecordId == 0) 
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
                var record = Db.MedicalRecords.FirstOrDefault(p => p.MedicalRecordId == recordID); 

                if (record == null)
                    return (true, "Medical Record is not Found in DB");

                Db.MedicalRecords.Remove(record);
                Db.SaveChanges();

                return (false, null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }

        (bool, string?) IMedicalRecordRepo.Edit(MedicalRecord newRecord, int oldRecordID) 
        {
            try
            {
                var oldRecord = Db.MedicalRecords.Where(a => a.MedicalRecordId == oldRecordID).FirstOrDefault(); 

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

        (bool, string?, List<MedicalRecord>?) IMedicalRecordRepo.GetAll(Expression<Func<MedicalRecord, bool>> filter)
        {
            try
            {
                var result = Db.MedicalRecords.Where(filter).ToList();
                if (result.Count > 0)
                    return (false, null, result);
                return (true, "There is no Data", null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message, null);
            }
        }

        (bool, string?, List<MedicalRecord>?) IMedicalRecordRepo.GetAll()
        {
            try
            {
                var result = Db.MedicalRecords.ToList();
                if (result.Count > 0)
                    return (false, null, result);
                return (true, "There is no Data", null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message, null);
            }
        }

        (bool, string?, MedicalRecord?) IMedicalRecordRepo.GetByID(int recordID) 
        {
            try
            {
                var record = Db.MedicalRecords.FirstOrDefault(u => u.MedicalRecordId == recordID); 
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
