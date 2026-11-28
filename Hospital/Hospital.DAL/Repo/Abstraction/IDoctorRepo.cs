
namespace Hospital.DAL.Repo.Abstraction
{
    public interface IDoctorRepo
    {
        (bool, string?) Create(Doctor doctor);
        (bool, string?) Edite(Doctor newdoctor, string olddoctorId);
        (bool, string?) Delete(string doctorId);
        (bool, string?, Doctor?) GetById(string doctorId);
        (bool, string?, List<Doctor>?) GetAll(Expression<Func<Doctor, bool>> filter);
    }
}
