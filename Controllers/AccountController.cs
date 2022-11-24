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
        private readonly ISession? _session;

        //constructor
        public AccountController(IConfiguration config, ReeditContext context, IHttpContextAccessor httpContextAccessor)
        {
            _config = config;
            _accountDAO = new(context);
            _session = httpContextAccessor?.HttpContext?.Session;
        }

        //methods
        public IActionResult Signup(string? error)
        {
            ViewData["Title"] = "Sign Up";
            ViewBag.Error = error;
            return View("Signup");
        }

        public IActionResult SignupResult(string username, string email, string password, string confirm_password)
        {
            if (password.Equals(confirm_password))
            {
                if (!_accountDAO.EmailIsTaken(email))
                {
                    if (_accountDAO.AddUser(username, email, password))
                    {
                        User user = _accountDAO.GetUser(username, password);
                        _session?.SetInt32("Uid", user.Uid);
                        return RedirectToAction("Home", "Home");
                    }
                    else return RedirectToAction("Signup", new { error = "There was an unexpected error. Please try again." });
                }
                else
                {
                    return RedirectToAction("Signup", new { error = "The email is already in use." });
                }
            }
            else
            {
                return RedirectToAction("Signup", new { error="The passwords do not match."});
            }
        }

        public IActionResult Signin(string? error)
        {
            ViewData["Title"] = "Sign In";
            ViewBag.Error = error;
            return View("Signin");
        }

        public IActionResult SigninResult(string email, string password)
        {
            if (_accountDAO.UserExists(email, password)) {
                User user = _accountDAO.GetUser(email, password);
                int uid = user.Uid;
                _session?.SetInt32("Uid", user.Uid);
                return RedirectToAction("Home", "Home", new { uid });
            }
            else return RedirectToAction("Signin", new { error="This user does not exist." });
        }

        public IActionResult Signout()
        {
            _session?.Clear();
            return RedirectToAction("Signin");
        }
    }
}
