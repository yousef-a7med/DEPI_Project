namespace Hospital.BLL.Service.Abstraction
{
    public interface IUserService
    {
        public (bool, string) Create(CreateUserVM createUserVM);
    }
}
