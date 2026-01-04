using Microsoft.AspNetCore.Mvc;

namespace HospitalPL.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
