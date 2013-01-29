using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CNM.Models;

namespace CNM.Web.ViewModels.Search
{
    public class SearchFormViewModel : ViewModelBase, IValidatableObject
    {
        public IEnumerable<Skill> Skills { get; set; }
        public IEnumerable<ServiceArea> ServiceAreas { get; set; }

        public IEnumerable<Skill> SelectedSkills { get; set; }
        public IEnumerable<ServiceArea> SelectedServiceAreas { get; set; }


        public string[] States { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public int? PageNumber { get; set; }

        public SearchFormViewModel()
        {
            Skills = new List<Skill>();
            ServiceAreas = new List<ServiceArea>();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (SelectedSkills == null || SelectedSkills.Count() == 0)
                yield return new ValidationResult("You must select at least one skill.", new string[] { "skills" });

            if (SelectedServiceAreas == null || SelectedServiceAreas.Count() == 0)
                yield return new ValidationResult("You must select at least one service area.", new string[] { "serviceareas" });
        }
    }
}