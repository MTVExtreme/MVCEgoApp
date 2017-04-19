using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalityEgo.Models
{
    public class Trial
    {
        [Key]
        public int TrialID { get; set; }

        [ForeignKey("Personality")]
        public int ProscuterID { get; set; }
        [ForeignKey("Personality")]
        public int PlaintiffID { get; set; }

        [ForeignKey("Personality")]
        public int AttornyID { get; set; }
        [ForeignKey("Personality")]
        public int DefendantID { get; set; }

        [ForeignKey("Personality")]
        public int JudgeID { get; set; }

        [ForeignKey("Charge")]
        public int ChargeID { get; set; }

        public bool? Result { get; set; }
        public bool IsComplete { get; set; }
        
        public ICollection<Personality> Personality { get; set; }
        public Charge Charge { get; set; }


    }
}