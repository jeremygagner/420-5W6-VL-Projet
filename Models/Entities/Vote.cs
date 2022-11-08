using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _420_5W6_VL_Projet.Models.Entities
{
    public class Vote
    {
        //attributes
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Vid { get; set; }
        [ForeignKey("User")]
        public int Uid { get; set; }
        [ForeignKey("Link")]
        public int Lid { get; set; }
        public int Value { get; set; }
    }
}
