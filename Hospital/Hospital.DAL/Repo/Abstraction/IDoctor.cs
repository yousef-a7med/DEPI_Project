
namespace Hospital.DAL.Repo.Abstraction
{
    public interface IDoctor
    {
        (bool, string?) Create(Doctor doctor);
        (bool, string?) Edite(Doctor newdoctor, int olddoctorId);
        (bool, string?) Delete(int doctorId);
        (bool, string?, Doctor?) GetById(int doctorId);
        (bool, string?, List<Doctor>?) GetAll();
    }
}
