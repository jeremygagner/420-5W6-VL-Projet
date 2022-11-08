using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _420_5W6_VL_Projet.Models.Entities
{
    public class Comment
    {
        //attributes
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Cid { get; set; }
        [ForeignKey("User")]
        public int Uid { get; set; }
        [ForeignKey("Link")]
        public int Lid { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }

        //navigation
        public virtual User User { get; set; }
        public virtual Link Link { get; set; }
    }
}
