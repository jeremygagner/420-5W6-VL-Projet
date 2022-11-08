using _420_5W6_VL_Projet.Models;
using _420_5W6_VL_Projet.Models.DAL;
using _420_5W6_VL_Projet.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace _420_5W6_VL_Projet.Controllers
{
    public class AccountController : Controller
    {
        //attributes
        private readonly IConfiguration _config;
        private readonly AccountDAO _accountDAO;

        //constructor
        public AccountController(IConfiguration config, ReeditContext context)
        {
            _config = config;
            _accountDAO = new(context);
        }

        //methods
        public IActionResult Signup()
        {
            ViewData["Title"] = "Sign Up";
            return View("Signup");
        }

        public IActionResult SignupResult(string username, string email, string password, string confirm_password)
        {
            if (password.Equals(confirm_password))
            {
                if (!_accountDAO.EmailIsTaken(email))
                {
                    if (_accountDAO.AddUser(username, email, password)) return RedirectToAction("Home", "Home");
                    else return RedirectToAction("Signup");
                }
                else
                {
                    return RedirectToAction("Signup");
                }
            }
            else
            {
                return RedirectToAction("Signup");
            }
        }

        public IActionResult Signin()
        {
            ViewData["Title"] = "Sign In";
            return View("Signin");
        }

        public IActionResult SigninResult(string email, string password)
        {
            if (_accountDAO.UserExists(email, password)) {
                User user = _accountDAO.GetUser(email, password);
                int uid = user.Uid;
                return RedirectToAction("Home", "Home", new { uid });
            }
            else return RedirectToAction("Signin");
        }

        public IActionResult Signout()
        {
            return RedirectToAction("Signin");
        }
    }
}
