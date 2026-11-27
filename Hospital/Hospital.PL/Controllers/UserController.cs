
using Hospital.DAL.DataBase;
using Hospital.DAL.Entities;

namespace Hospital.PL.Controllers
{
    public class UserController : Controller
    {
        HospitalDbContext Db = new HospitalDbContext();
        public IActionResult Create()
        {

            return View();
        }

        public IActionResult Save()
        {

            return View();
        }

        public IActionResult GetAll(User User)
        {
            var result = Db.Users.ToList();
            return View(result);
        }
    }
}
