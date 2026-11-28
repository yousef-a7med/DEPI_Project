
namespace Hospital.DAL.Repo.Abstraction
{
    public interface IPrescriptionItemRepo
    {
        (bool, string?) Create(PrescriptionItem prescriptionItem);
        (bool, string?) Edit(PrescriptionItem newPrescriptionItem, int oldPrescriptionItemId);
        (bool, string?) Delete(int prescriptionItemId);
        (bool, string?, PrescriptionItem?) GetById(int prescriptionItemId);
        (bool, string?, List<PrescriptionItem>?) GetAll(Expression<Func<PrescriptionItem, bool>> filter);
        (bool, string?, PrescriptionItem?) GetByFilter(Expression<Func<PrescriptionItem, bool>> filter);
    }
}