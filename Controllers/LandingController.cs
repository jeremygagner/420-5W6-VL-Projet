using Microsoft.AspNetCore.Mvc;

namespace _420_5W6_VL_Projet.Controllers
{
    public class LandingController : Controller
    {
        public IActionResult Landing()
        {
            return View("Landing");
        }
    }
}
