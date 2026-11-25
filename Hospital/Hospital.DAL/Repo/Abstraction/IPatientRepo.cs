using System.Linq.Expressions;
namespace Hospital.DAL.Repo.Abstraction
{
    public interface IPatientRepo
    {
        (bool, string?) Create(Patient patient);
        (bool, string?) Edit(Patient newPatient, int oldPatientID);
        (bool, string?, List<Patient>?) GetAll();
        (bool, string?, Patient?) GetByID(int PatientID);
        (bool, string?) Delete(int PatientID);
        (bool, string?, List<Patient>?) GetAll(Expression<Func<Patient, bool>> filter);
    }
}
