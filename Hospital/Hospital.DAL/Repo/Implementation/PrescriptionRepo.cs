namespace Hospital.DAL.Repo.Implementation
{
    public class PrescriptionRepo : IPrescriptionRepo
    {
        private readonly HospitalDbContext Db = new HospitalDbContext();

        public (bool, string?) Create(Prescription prescription)
        {
            try
            {
                var result = Db.Prescriptions.Add(prescription);
                Db.SaveChanges();
                if (result.Entity.PrescriptionId == null)
                    return (true, "Prescription not added in DB :(");

                return (false, null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }

        public (bool, string?) Edit(Prescription newPrescription, int oldPrescriptionId)
        {
            try
            {
                var oldPrescription = Db.Prescriptions.Where(a => a.PrescriptionId == oldPrescriptionId).FirstOrDefault();
                if (oldPrescription == null)
                    return (true, "There is no Prescription in Db :(");

                oldPrescription.IssuedDate = newPrescription.IssuedDate;
                oldPrescription.Status = newPrescription.Status;
                oldPrescription.Instructions = newPrescription.Instructions;
                oldPrescription.MedicalRecordId = newPrescription.MedicalRecordId;
                oldPrescription.PatientId = newPrescription.PatientId;

                Db.SaveChanges();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }

        public (bool, string?, List<Prescription>?) GetAll(Expression<Func<Prescription, bool>>? filter)
        {
            try
            {
                var result = Db.Prescriptions.Where(filter).ToList();

                if (result.Count > 0)
                    return (false, null, result);

                return (true, "There is no Data :(", null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message, null);
            }
        }

        public (bool, string?, Prescription?) GetById(int prescriptionId)
        {
            try
            {
                var prescription = Db.Prescriptions.Where(a => a.PrescriptionId == prescriptionId).FirstOrDefault();
                if (prescription == null)
                    return (true, "There is no Prescription in Db :(", null);

                return (false, null, prescription);
            }
            catch (Exception ex)
            {
                return (true, ex.Message, null);
            }
        }

        public (bool, string?) Delete(int prescriptionId)
        {
            try
            {
                var prescription = Db.Prescriptions.Where(a => a.PrescriptionId == prescriptionId).FirstOrDefault();
                if (prescription == null)
                    return (true, "There is no Prescription in Db :(");

                Db.Prescriptions.Remove(prescription);
                Db.SaveChanges();
                return (false, null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }
    }
}