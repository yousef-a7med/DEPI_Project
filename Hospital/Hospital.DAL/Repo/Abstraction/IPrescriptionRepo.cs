namespace Hospital.DAL.Repo.Abstraction
{
    public interface IPrescriptionRepo
    {
        (bool, string?) Create(Prescription prescription);
        (bool, string?) Edit(Prescription newPrescription, int oldPrescriptionId);
        (bool, string?, List<Prescription>?) GetAll(Expression<Func<Prescription, bool>>? filter);
        (bool, string?, Prescription?) GetById(int prescriptionId);
        (bool, string?) Delete(int prescriptionId);
    }
}