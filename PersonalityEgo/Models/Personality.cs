using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalityEgo.Models
{

    public enum Gender
    {
        Undefined, Male, Female, 
    }

    public class Personality
    {
        [Key]
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

        [ForeignKey("Role")]
        public int RoleID { get; set; }


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


        public virtual Role Role { get; set; }


    }
}