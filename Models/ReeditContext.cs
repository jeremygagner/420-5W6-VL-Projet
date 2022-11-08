using _420_5W6_VL_Projet.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace _420_5W6_VL_Projet.Models
{
    public class ReeditContext : DbContext
    {
        //constructors
        public ReeditContext() { }
        public ReeditContext(DbContextOptions options) : base(options) { }

        //dbsets
        public DbSet<User> Users { get; set; }
        public DbSet<Link> Link { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<User>().HasData(
                new User { Uid = 1, Username = "projet_admin", Email = "projetadmin@gmail.com", Password = "Admin123!"},
                new User { Uid = 2, Username = "projet_user", Email = "projetuser@gmail.com", Password = "User123!"}
            );
            builder.Entity<Link>().HasData(
                new Link { Lid = 1, Uid = 1, Date = DateTime.Now, Url = "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Lord_of_the_Rings_The_Fellowship_of_the_Ring_%282001%29.jpg", Description = "The Lord of the Rings, The Fellowship of the Ring" },
                new Link { Lid = 2, Uid = 1, Date = DateTime.Now, Url = "https://upload.wikimedia.org/wikipedia/en/d/d0/Lord_of_the_Rings_-_The_Two_Towers_%282002%29.jpg", Description = "The Lord of the Rings, The Two Towers" },
                new Link { Lid = 3, Uid = 1, Date = DateTime.Now, Url = "https://upload.wikimedia.org/wikipedia/en/b/be/The_Lord_of_the_Rings_-_The_Return_of_the_King_%282003%29.jpg", Description = "The Lord of the Rings, The Return of the King" },
                new Link { Lid = 4, Uid = 1, Date = DateTime.Now, Url = "https://upload.wikimedia.org/wikipedia/en/b/b3/The_Hobbit-_An_Unexpected_Journey.jpeg", Description = "The Hobbit, An Unexpected Journey" },
                new Link { Lid = 5, Uid = 1, Date = DateTime.Now, Url = "https://upload.wikimedia.org/wikipedia/en/4/4f/The_Hobbit_-_The_Desolation_of_Smaug_theatrical_poster.jpg", Description = "The Hobbit, The Desolation of Smaug" },
                new Link { Lid = 6, Uid = 1, Date = DateTime.Now, Url = "https://upload.wikimedia.org/wikipedia/en/e/e7/The_Hobbit_-_The_Battle_of_the_Five_Armies.png", Description = "The Hobbit, The Battle of the Five Armies" }
            );
        }
    }
}
