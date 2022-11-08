using _420_5W6_VL_Projet.Models.Entities;

namespace _420_5W6_VL_Projet.Models.DAL
{
    public class CommentDAO
    {
        //attributes
        private readonly ReeditContext _context;

        //constructor
        public CommentDAO(ReeditContext context)
        {
            _context = context;
        }

        //methods
        public bool Post(Comment comment)
        {
            _context.Comments.Add(comment);
            if (_context.SaveChanges() == 1) return true;
            else return false;
        }
    }
}
