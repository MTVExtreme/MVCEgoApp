using System.ComponentModel.DataAnnotations;

namespace PersonalityEgo.Models
{
    public class Trial
    {
        [Key]
        public int TrialID { get; set; }
        public int ProscuterID { get; set; }
        public int PlaintiffID { get; set; }

        public int AttornyID { get; set; }
        public int DefendantID { get; set; }

        public int JudgeID { get; set; }

        public int ChargeID { get; set; }

        public bool? Result { get; set; }
        public bool IsComplete { get; set; }
        
        public Personality Personality { get; set; }
        public Charge Charge { get; set; }


    }
}