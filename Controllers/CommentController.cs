using _420_5W6_VL_Projet.Models.DAL;
using _420_5W6_VL_Projet.Models;
using _420_5W6_VL_Projet.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace _420_5W6_VL_Projet.Controllers
{
    public class CommentController : Controller
    {
        //attributes
        private readonly IConfiguration _config;
        private readonly CommentDAO _commentDAO;

        //constructor
        public CommentController(IConfiguration config, ReeditContext context)
        {
            _config = config;
            _commentDAO = new(context);
        }

        //methods
        public IActionResult Post(int uid, int lid, string comment)
        {
            Comment newComment = new()
            {
                Uid = uid,
                Lid = lid,
                Text = comment,
                Date = DateTime.Now
            };
            _commentDAO.Post(newComment);
            return RedirectToAction("ALink", "Link", new { uid, lid });
        }
    }
}
