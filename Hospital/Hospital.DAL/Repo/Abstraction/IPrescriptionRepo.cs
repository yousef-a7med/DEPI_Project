using Hospital.DAL.Entities;
using System.Linq.Expressions;

namespace Hospital.DAL.Repo.Abstraction
{
    public interface IPrescriptionRepo
    {
        (bool, string?) Create(Prescription prescription);
        (bool, string?) Edit(Prescription newPrescription, string oldPrescriptionId);
        (bool, string?, List<Prescription>?) GetAll(Expression<Func<Prescription, bool>>? filter);
        (bool, string?, Prescription?) GetById(string prescriptionId);
        (bool, string?) Delete(string prescriptionId);
    }
}