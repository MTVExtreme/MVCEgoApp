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
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true, NullDisplayText = "Unknown Birthday")]
        public DateTime? Birthday { get; set; }

        private int? _mentalAge;

        [Display(Name = "Mental Age")]
        [DisplayFormat(NullDisplayText="Unknown Age", ApplyFormatInEditMode=true)]
        public int? MentalAge
        {
            get
            {
                if (Birthday != null)
                {
                    _mentalAge = DateTime.Now.Year - Birthday.Value.Year;
                    return _mentalAge;
                }
                else return _mentalAge;
            }

            set
            {
                _mentalAge = value;
            }

        }

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