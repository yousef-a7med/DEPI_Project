
namespace Hospital.BLL.Service.Implementation
{
    public class UserService : IUserService
    {
        private IUserRepo userRepo = new UserRepo();
        public (bool, string) Create(CreateUserVM createUserVM)
        {
            try
            {
                var Check_User = userRepo.GetByFilter(a => a.Email.ToLower() == createUserVM.Email.ToLower());
                if (!Check_User.Item1)
                    return (true, "User must be unique");
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
}
    }
}
