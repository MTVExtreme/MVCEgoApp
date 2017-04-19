using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalityEgo.Models
{
    public class Role
    {
        public int RoleID { get; set; }
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }


        public string RoleName { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }
        public virtual Department Department { get; set; }

    }
}