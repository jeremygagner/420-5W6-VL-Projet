using _420_5W6_VL_Projet.Models;
using _420_5W6_VL_Projet.Models.DAL;
using _420_5W6_VL_Projet.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace _420_5W6_VL_Projet.Controllers
{
    public class HomeController : Controller
    {
        //attributes
        private readonly IConfiguration _config;
        private readonly LinkDAO _linkDAO;
        //constructor
        public HomeController(IConfiguration config, ReeditContext context)
        {
            _config = config;
            _linkDAO = new(context);
        }

        //methods
        public IActionResult Home(int uid)
        {
            ViewData["Title"] = "Home";
            ViewBag.Uid = uid;
            return View("Home", _linkDAO.Get20BestLinks());
        }
    }
}
