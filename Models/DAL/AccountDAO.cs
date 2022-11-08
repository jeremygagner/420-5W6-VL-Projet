using _420_5W6_VL_Projet.Models.Entities;

namespace _420_5W6_VL_Projet.Models.DAL
{
    public class AccountDAO
    {
        //attributes
        private readonly ReeditContext _context;

        //constructor
        public AccountDAO(ReeditContext context)
        {
            _context = context;
        }

        //methods
        public bool EmailIsTaken(string email)
        {
            return _context.Users.Where(user => user.Email.ToLower().Equals(email.ToLower())).Any();
        }

        public bool UserExists(string email, string password)
        {
            return _context.Users.Where(user => user.Email.ToLower().Equals(email.ToLower()) && user.Password.Equals(password)).Any();
        }
        
        public User GetUser(string email, string password)
        {
            return _context.Users.Where(user => user.Email.ToLower().Equals(email.ToLower()) && user.Password.Equals(password)).First();
        }

        public bool AddUser(string username, string email, string password)
        {
            _context.Users.Add(new User()
            {
                Username = username,
                Email = email,
                Password = password,
            });
            return _context.SaveChanges() == 1;
        }
    }
}
