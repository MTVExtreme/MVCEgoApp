using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalityEgo.Models
{
    public class Trial
    {
        public int ProscuterID { get; set; }
        public int PlaintiffID { get; set; }

        public int AttornyID { get; set; }
        public int DefendantID { get; set; }

        public int JudgeID { get; set; }
        
        public Personality Personality { get; set; }
        public Role Role { get; set; }


    }
}