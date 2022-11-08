using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _420_5W6_VL_Projet.Models.Entities
{
    public class User
    {
        //attributes
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Uid { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //navigation
        public virtual IList<Link> Links { get; set; }
        public virtual IList<Comment> Comments { get; set; }
        public virtual IList<Vote> Votes { get; set; }
    }
}
