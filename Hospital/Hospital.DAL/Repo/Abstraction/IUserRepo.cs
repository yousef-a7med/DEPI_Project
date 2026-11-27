namespace Hospital.DAL.Repo.Abstraction
{
    public interface IUserRepo
    {
        (bool, string?) Create(User user);
        (bool, string?) Edit(User newUser , string oldUserID);
        (bool, string?, List <User>?) GetAll(Expression<Func<User,bool>> filter);
        (bool, string?, User?) GetByFilter(Expression<Func<User, bool>> filter);
        (bool, string?, User?) GetByID(string UserID);
        (bool, string?) Delete(string UserID);


    }
}
