using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalityEgo.Models
{
    public class Role
    {
        public int RoleID { get; set; }
        [ForeignKey("Skill")]
        public int SkillID { get; set; }
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        [ForeignKey("Personality")]
        public int PersonalityID { get; set; }

        public string RoleName { get; set; }

        public virtual ICollection<Skill> Personality { get; set;}
        public virtual ICollection<Skill> Skills { get; set; }
    }
}