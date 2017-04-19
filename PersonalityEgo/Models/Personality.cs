using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalityEgo.Models
{

    public enum Gender
    {
        Male, Female, Undefined
    }

    public class Personality
    {
        public int ID { get; set; }
        [Required]
        [StringLength(15)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "First Name")]
        public string LastName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Display(Name = "Mental Age")]
        [DisplayFormat(NullDisplayText = "Unknown Mental Age")]
        public int? MentalAge { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd}", ApplyFormatInEditMode = true, NullDisplayText = "Unknown Birthday")]
        public DateTime? Birthday { get; set; }

       

        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        public virtual ICollection<Skill> Skills {get; set;}
        public virtual ICollection<Role> Roles { get; set; }

    }
}