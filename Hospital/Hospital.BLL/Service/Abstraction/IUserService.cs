namespace Hospital.BLL.Service.Abstraction
{
    public interface IUserService
    {
        public (bool, string?) Create(CreateUserVM createUserVM);
        public (bool, string?) Edit(CreateUserVM createUserVM);
        public (bool, string?) Delete(CreateUserVM createUserVM);
        public (bool, string?) GetAll(List<CreateUserVM> createUserVMs);
    }
}
