using System.Collections.Generic;

namespace PersonalityEgo.Models
{
    public class Role
    {
        public int RoleID { get; set; }
        public int SkillID { get; set; }
        public int DepartmentID { get; set; }
        public int PersonalityID { get; set; }

        public string RoleName { get; set; }

        public virtual ICollection<Skill> Personality { get; set;}
        public virtual ICollection<Skill> Skills { get; set; }
    }
}