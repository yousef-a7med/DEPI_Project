namespace Hospital.DAL.Repo.Abstraction
{
    public interface IMedicalRecordRepo
    {
        (bool, string?) Create(MedicalRecord medicalRecord);
        (bool, string?) Edit(MedicalRecord newMedicalRecord, int oldRecordID);
        (bool, string?) Delete(int recordID);
        (bool, string?, MedicalRecord?) GetByID(int recordID);
        (bool, string?, List<MedicalRecord>?) GetAll();
        (bool, string?, List<MedicalRecord>?) GetAll(Expression<Func<MedicalRecord, bool>> filter);
    }
}