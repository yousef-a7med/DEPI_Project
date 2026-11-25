using Microsoft.AspNetCore.Mvc;
namespace Hospital.PL.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
