using _420_5W6_VL_Projet.Models.Entities;
using System.Net.NetworkInformation;

namespace _420_5W6_VL_Projet.Models.DAL
{
    public class LinkDAO
    {
        //attributes
        private readonly ReeditContext _context;

        //constructor
        public LinkDAO(ReeditContext context)
        {
            _context = context;
        }

        //methods
        public IEnumerable<Link> Get20BestLinks()
        {
            return _context.Link.OrderBy(link => link.Votes.Select(vote => vote.Value == 1).Count()).Take(20);
        }

        public IEnumerable<Link> GetMyLinks(int uid)
        {
            return _context.Link.Where(link => link.Uid == uid).ToList();
        }

        public Link? GetLink(int lid)
        {
            return _context.Link.Where(link => link.Lid == lid).FirstOrDefault();
        }

        public bool IsImage(string url)
        {
            Uri uri = new Uri(url);
            string apath = uri.AbsolutePath;
            string extension = Path.GetExtension(apath).ToLower();
            if (extension.Equals(".png") || extension.Equals(".jpg") || extension.Equals(".jpeg")) return true;
            else return false;
        }

        public bool Post(int uid, string url, string desc)
        {
            Link link = new()
            {
                Uid = uid,
                Url = url,
                Description = desc,
                Date = DateTime.Now
            };
            _context.Link.Add(link);
            if (_context.SaveChanges() == 1) return true;
            else return false;
        }

        public bool Delete(int uid, int lid)
        {
            Link link = _context.Link.Where(link => link.Uid == uid && link.Lid == lid).First();
            _context.Remove(link);
            if (_context.SaveChanges() == 1) return true;
            else return false;
        }
    }
}
