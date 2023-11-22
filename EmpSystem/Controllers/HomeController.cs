using Microsoft.AspNetCore.Mvc;

namespace EmpSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ColorCards()
        {
            return View();
        }
    }
}
