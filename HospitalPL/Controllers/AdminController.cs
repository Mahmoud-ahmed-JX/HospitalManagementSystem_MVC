using Microsoft.AspNetCore.Mvc;

namespace HospitalPL.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
