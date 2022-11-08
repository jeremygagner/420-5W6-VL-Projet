using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _420_5W6_VL_Projet.Models.Entities
{
    public class Link
    {
        //attributes
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Lid { get; set; }
        [ForeignKey("User")]
        public int Uid { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }

        //navigation
        public virtual User User { get; set; }
        public virtual IList<Comment> Comments { get; set; }
        public virtual IList<Vote> Votes { get; set; }
    }
}
