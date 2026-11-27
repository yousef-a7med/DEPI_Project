using Hospital.DAL.Entities; 
namespace Hospital.DAL.Repo.Abstraction
{
    public interface IMedicalRecordRepo
    {
        (bool, string?) Create(Medicsirecords medicalRecord);
        (bool, string?) Edit(Medicsirecords newMedicalRecord, string oldRecordID);
        (bool, string?) Delete(string recordID);
        (bool, string?, Medicsirecords?) GetByID(string recordID);
        (bool, string?, List<Medicsirecords>?) GetAll();
        (bool, string?, List<Medicsirecords>?) GetAll(Expression<Func<Medicsirecords, bool>> filter);
    }
}