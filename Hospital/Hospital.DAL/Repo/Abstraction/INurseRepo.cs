namespace Hospital.DAL.Repo.Abstraction
{
    public interface INurseRepo
    {
        (bool, string?) Create(Nurse nurse);
        (bool, string?) Edit(Nurse newNurse, string oldNurseId);
        (bool, string?, List<Nurse>?) GetAll(Expression<Func<Nurse, bool>>? filter);
        (bool, string?, Nurse?) GetById(string nurseId);
        (bool, string?) Delete(string nurseId);
    }
}