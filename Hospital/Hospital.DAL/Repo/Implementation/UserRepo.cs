namespace Hospital.DAL.Repo.Implementation
{
    public class UserRepo : IUserRepo
    {
        private readonly HospitalDbContext Db = new HospitalDbContext();
        (bool, string?) IUserRepo.Create(User user)
        {
            try
            {
                var result = Db.Users.Add(user);
                Db.SaveChanges();
                if (string.IsNullOrEmpty(result.Entity.ID))
                    return (true, "User Not Added in DB");
                return (false, null);

            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }

        (bool, string?) IUserRepo.Delete(string UserID)
        {
            try
            {
                var user = Db.Users.FirstOrDefault(u => u.ID == UserID);
                if (user.ID == null)
                    return (true, "User is not Found in DB");

                Db.Users.Remove(user);
                Db.SaveChanges();

                return (false, null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }

        (bool, string?) IUserRepo.Edit(User newuser, string oldUserID)
        {
            try
            {
                var oldUser = Db.Users.Where(a => a.ID == oldUserID).FirstOrDefault();
                if (oldUser != null)
                    return (true, "There is no user in DB");
                oldUser.FullName = newuser.FullName;
                oldUser.Email = newuser.Email;
                oldUser.Password = newuser.Password;
                oldUser.Role = newuser.Role;
                oldUser.IsActive = newuser.IsActive;
                Db.SaveChanges();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message);
            }
        }

        (bool, string?, List<User>?) IUserRepo.GetAll(Expression<Func<User, bool>> filter)
        {
            try
            {
                var result = Db.Users.Where(filter).ToList();
                if (result.Count > 0)
                    return (false, null, result);
                return (true, "There is no Data", null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message, null);
            }
        }

        (bool, string?, User?) IUserRepo.GetByFilter(Expression<Func<User, bool>> filter)
        {
            try
            {
                var result = Db.Users.Where(filter).FirstOrDefault();
                if (result != null)
                    return (false, null, result);
                return (true, "There is no Data", null);
            }
            catch (Exception ex)
            {
                return (true, ex.Message, null);
            }
        }

        (bool, string?, User?) IUserRepo.GetByID(string UserID)
        {
            try
            {
                var user = Db.Users.FirstOrDefault(u => u.ID == UserID);
                if (user.ID == null)
                    return (true, "User is not Found in DB", null);

                return (false, null, user);
            }
            catch (Exception ex)
            {
                 return (true, ex.Message,null);
            }
        }
    }
}
