using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalityEgo.Models
{
    public class RoleAssignment
    {
        public int RoleID { get; set; }
        public int SKillID { get; set; }
        public int PersonalityID { get; set; }

        public virtual Personality Personality { get; set; }
        public virtual Skill Skill { get; set; }
    }
}