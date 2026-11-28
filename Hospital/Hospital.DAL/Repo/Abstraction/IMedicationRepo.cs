
namespace Hospital.DAL.Repo.Abstraction
{
    public interface IMedicationRepo
    {
        (bool, string?) Create(Medication medication);
        (bool, string?) Edit(Medication newMedication, int oldMedicationId);
        (bool, string?) Delete(int medicationId);
        (bool, string?, Medication?) GetById(int medicationId);
        (bool, string?, List<Medication>?) GetAll();
        (bool, string?, List<Medication>?) GetAll(Expression<Func<Medication, bool>> filter);
    }
}