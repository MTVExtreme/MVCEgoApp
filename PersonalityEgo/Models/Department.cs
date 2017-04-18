using System.ComponentModel.DataAnnotations;

namespace PersonalityEgo.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        public int Members { get; set; }
    }
}