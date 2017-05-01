using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalityEgo.Models
{
    public class Trial
    {
        [Key]
        public int TrialID { get; set; }

        [ForeignKey("Charge")]
        public int ChargeID { get; set; }

        public DateTime? TrialDate { get; set; }

        public bool? Result { get; set; }
        public bool IsComplete { get; set; }
        
        public ICollection<Personality> Personalities { get; set; }
        public Charge Charge { get; set; }


    }
}