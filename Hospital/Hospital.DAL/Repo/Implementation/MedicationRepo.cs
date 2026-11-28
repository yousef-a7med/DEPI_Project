
namespace Hospital.DAL.Repo.Implementation
{
    internal class MedicationRepo : IMedicationRepo
    {
        private readonly HospitalDbContext Db = new HospitalDbContext();

        (bool, string?) IMedicationRepo.Create(Medication medication)
        {
            try
            {
                var result = Db.Medications.Add(medication);
                Db.SaveChanges();
                
                if (result.Entity.MedicationsId == 0)
                    return (true, "Medication Not Added in DB");

                return (false, null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }

        (bool, string?) IMedicationRepo.Delete(int medicationId)
        {
            try
            {
                var med = Db.Medications.FirstOrDefault(p => p.MedicationsId == medicationId);

                if (med == null)
                    return (true, "Medication is not Found in DB");

                Db.Medications.Remove(med);
                Db.SaveChanges();

                return (false, null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }

        (bool, string?) IMedicationRepo.Edit(Medication newMedication, int oldMedicationId)
        {
            try
            {
                var oldMed = Db.Medications.Where(a => a.MedicationsId == oldMedicationId).FirstOrDefault();

                if (oldMed == null)
                    return (true, "There is no Medication in DB");

                oldMed.Name = newMedication.Name;
                oldMed.StockQuantity = newMedication.StockQuantity;
                oldMed.UnitPrice = newMedication.UnitPrice;
                oldMed.ExpiryDate = newMedication.ExpiryDate;

                Db.SaveChanges();

                return (false, null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }

        (bool, string?, List<Medication>?) IMedicationRepo.GetAll()
        {
            try
            {
                var result = Db.Medications.ToList();
                if (result.Count > 0)
                    return (false, null, result);
                return (true, "There is no Data", null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message, null);
            }
        }

        (bool, string?, List<Medication>?) IMedicationRepo.GetAll(Expression<Func<Medication, bool>> filter)
        {
            try
            {
                var result = Db.Medications.Where(filter).ToList();
                if (result.Count > 0)
                    return (false, null, result);
                return (true, "There is no Data", null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message, null);
            }
        }

        (bool, string?, Medication?) IMedicationRepo.GetById(int medicationId)
        {
            try
            {
                var med = Db.Medications.FirstOrDefault(u => u.MedicationsId == medicationId);
                if (med == null)
                    return (true, "Medication is not Found in DB", null);

                return (false, null, med);
            }
            catch (Exception ex)
            {
                return (true, ex.Message, null);
            }
        }
    }
}