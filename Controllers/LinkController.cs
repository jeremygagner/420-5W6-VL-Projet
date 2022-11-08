using _420_5W6_VL_Projet.Models.DAL;
using _420_5W6_VL_Projet.Models;
using Microsoft.AspNetCore.Mvc;
using _420_5W6_VL_Projet.Models.Entities;

namespace _420_5W6_VL_Projet.Controllers
{
    public class LinkController : Controller
    {
        //attributes
        private readonly IConfiguration _config;
        private readonly LinkDAO _linkDAO;
        private readonly VoteDAO _voteDAO;

        //constructor
        public LinkController(IConfiguration config, ReeditContext context)
        {
            _config = config;
            _linkDAO = new(context);
            _voteDAO = new(context);
        }

        //methods
        public IActionResult MyLinks(int uid)
        {
            ViewData["Title"] = "My Links";
            ViewBag.Uid = uid;
            ViewBag.LDAO = _linkDAO;
            return View("MyLinks", _linkDAO.GetMyLinks(uid));
        }

        public IActionResult ALink(int uid, int lid)
        {
            ViewData["Title"] = "Link #" + lid;
            ViewBag.Uid = uid;
            ViewBag.VDAO = _voteDAO;
            Link? link = _linkDAO.GetLink(lid);
            if (link != null) return View("ALink", link);
            else return RedirectToAction("Home", "Home", uid);
        }

        public IActionResult Vote(int value, int uid, int lid)
        {
            _voteDAO.Vote(value, uid, lid);
            return RedirectToAction("ALink", "Link", new { uid, lid });
        }

        public IActionResult PostLink(int uid)
        {
            ViewData["Title"] = "New Link";
            ViewBag.Uid = uid;
            return View("PostLink");
        }

        public IActionResult Post(int uid, string url, string desc)
        {
            if (_linkDAO.Post(uid, url, desc)) return RedirectToAction("Home", "Home", uid);
            else return RedirectToAction("PostLink", "Link", uid);
        }

        public IActionResult Delete(int uid, int lid)
        {
            if (_linkDAO.Delete(uid, lid)) return RedirectToAction("MyLinks", "Link", new { uid });
            else return RedirectToAction("Home", "Home", new { uid });
        }
    }
}
