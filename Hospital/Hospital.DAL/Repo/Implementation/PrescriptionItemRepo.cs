
namespace Hospital.DAL.Repo.Implementation
{
    internal class PrescriptionItemRepo : IPrescriptionItemRepo
    {
        private readonly HospitalDbContext Db = new HospitalDbContext();

        (bool, string?) IPrescriptionItemRepo.Create(PrescriptionItem prescriptionItem)
        {
            try
            {
                var result = Db.PrescriptionItems.Add(prescriptionItem);
                Db.SaveChanges();
               
                if (result.Entity.PrescriptionItemId == 0)
                    return (true, "PrescriptionItem Not Added in DB");

                return (false, null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }

        (bool, string?) IPrescriptionItemRepo.Delete(int prescriptionItemId)
        {
            try
            {
                var item = Db.PrescriptionItems.FirstOrDefault(p => p.PrescriptionItemId == prescriptionItemId);

                if (item == null)
                    return (true, "PrescriptionItem is not Found in DB");

                Db.PrescriptionItems.Remove(item);
                Db.SaveChanges();

                return (false, null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }

        (bool, string?) IPrescriptionItemRepo.Edit(PrescriptionItem newItem, int oldPrescriptionItemId)
        {
            try
            {
                var oldItem = Db.PrescriptionItems.Where(a => a.PrescriptionItemId == oldPrescriptionItemId).FirstOrDefault();

                if (oldItem == null)
                    return (true, "There is no PrescriptionItem in DB");

                oldItem.Frequency = newItem.Frequency;
                oldItem.Quantity = newItem.Quantity;
                oldItem.Duration = newItem.Duration;

                Db.SaveChanges();

                return (false, null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }

        (bool, string?, List<PrescriptionItem>?) IPrescriptionItemRepo.GetAll(Expression<Func<PrescriptionItem, bool>> filter)
        {
            try
            {
                var result = Db.PrescriptionItems.Where(filter).ToList();
                if (result.Count > 0)
                    return (false, null, result);
                return (true, "There is no Data", null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message, null);
            }
        }

        (bool, string?, PrescriptionItem?) IPrescriptionItemRepo.GetByFilter(Expression<Func<PrescriptionItem, bool>> filter)
        {
            try
            {
                var result = Db.PrescriptionItems.FirstOrDefault(filter);
                if (result == null)
                    return (false, null, result);
                return (true, "There is no Data", null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message, null);
            }
        }

        (bool, string?, PrescriptionItem?) IPrescriptionItemRepo.GetById(int prescriptionItemId)
        {
            try
            {
                var item = Db.PrescriptionItems.FirstOrDefault(u => u.PrescriptionItemId == prescriptionItemId);
                if (item == null)
                    return (true, "PrescriptionItem is not Found in DB", null);

                return (false, null, item);
            }
            catch (Exception ex)
            {
                return (true, ex.Message, null);
            }
        }
    }
}