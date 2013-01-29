using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CNM.Models
{
    public class Charity
    {
        public string CharityId { get; set; }

        [Required(ErrorMessage="An organization name is required.")]
        public string OrganizationName { get; set; }

        [Required(ErrorMessage="A first name is Required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage="A last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage="A phone number is required.")]
        public string Phone { get; set; }

        [Required(ErrorMessage="An email address is required.")]
        //[RegularExpression(@"(?>(?:[0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+)[a-zA-Z]{2,9}", ErrorMessage = "You must enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage="A website URL is required.")]
        public string Website { get; set; }

        [Required(ErrorMessage="An Address is required.")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        [Required(ErrorMessage="A city is required.")]
        public string City { get; set; }

        [Required(ErrorMessage="A state is required.")]
        public string State { get; set; }

        [Required(ErrorMessage="A postal code is required.")]
        public string PostalCode { get; set; }

        public short? YearsService { get; set; }

        [Required(ErrorMessage="An essay is required.")]
        public string Essay { get; set; }

        public bool IsSearchable { get; set; }

        public string Password { get; set; }

        public virtual ICollection<SkillEntity> NeededSkills { get; set; }
        public virtual ICollection<ServiceAreaEntity> NeededServiceAreas { get; set; }
    }
}
