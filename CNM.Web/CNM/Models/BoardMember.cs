using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CNM.Models
{
    public class BoardMember
    {
        public int BoardMemberId { get; set; }

        [Required(ErrorMessage = "A first name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "A last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "An employeer is required.")]
        public string Employer { get; set; }

        [Required(ErrorMessage = "A title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "A phone is required.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "An email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A password is required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "An address is required.")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        [Required(ErrorMessage = "A city is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "A state is required.")]
        public string State { get; set; }

        [Required(ErrorMessage = "A postal is required.")]
        public string PostalCode { get; set; }
        public string Ethnicity { get; set; }
        public string Gender { get; set; }
        public short YearsService { get; set; }

        [Required(ErrorMessage = "A mission stateme is required.")]
        public string MissionStatement { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage = "A birthday stateme is required.")]
        public DateTime BirthDay { get; set; }

        public bool IsSearchable { get; set; }

        public virtual ICollection<SkillEntity> AvailableSkills { get; set; }
        public virtual ICollection<ServiceAreaEntity> Interests { get; set; }
    }

    
}
