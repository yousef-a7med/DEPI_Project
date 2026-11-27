namespace Hospital.DAL.Repo.Abstraction
{
    public interface IPatientRepo 
    {
        (bool, string?) Create(Patient patient);
        (bool, string?) Edit(Patient newPatient, string oldPatientID);
        (bool, string?, List<Patient>?) GetAll();
        (bool, string?, Patient?) GetByID(string PatientID);
        (bool, string?) Delete(string PatientID);
        (bool, string?, List<Patient>?) GetAll(Expression<Func<Patient, bool>> filter);
    }
}
