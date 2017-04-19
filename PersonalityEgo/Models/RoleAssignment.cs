using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalityEgo.Models
{
    public class RoleAssignment
    {
        [Key]
        [ForeignKey("Personality")]
        public int PersonalityID { get; set; }
        [ForeignKey("Roles")]
        public int RoleID { get; set; }
        [ForeignKey("Skills")]
        public int SkillID { get; set; }
       

        public virtual Personality Personality { get; set; }
        public virtual Skill Skills { get; set; }
        public virtual Role Roles { get; set; }
    }
}