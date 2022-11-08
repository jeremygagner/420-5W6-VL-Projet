using _420_5W6_VL_Projet.Models.Entities;

namespace _420_5W6_VL_Projet.Models.DAL
{
    public class VoteDAO
    {
        //attributes
        private readonly ReeditContext _context;

        //constructor
        public VoteDAO(ReeditContext context)
        {
            _context = context;
        }

        //methods
        public int CountUpvotes(int lid)
        {
            return _context.Votes.Where(vote => vote.Lid == lid && vote.Value == 1).Count();
        }

        public int CountDownvotes(int lid)
        {
            return _context.Votes.Where(vote => vote.Lid == lid && vote.Value == -1).Count();
        }

        public bool HasVoted(int uid, int lid)
        {
            if (_context.Votes.Any(vote => vote.Uid == uid && vote.Lid == lid)) return true;
            else return false;
        }

        public bool Vote(int value, int uid, int lid)
        {
            if (HasVoted(uid, lid))
            {
                Vote vote = _context.Votes.Where(vote => vote.Uid == uid && vote.Lid == lid).First();
                vote.Value = value;
                _context.Votes.Update(vote);
                if (_context.SaveChanges() == 1) return true;
                else return false;
            }
            else
            {
                Vote vote = new()
                {
                    Uid = uid,
                    Lid = lid,
                    Value = value
                };
                _context.Votes.Add(vote);
                if (_context.SaveChanges() == 1) return true;
                else return false;
            }
        }
    }
}
