using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CNM.Models;

namespace CNM.Web.ViewModels.NonProfit
{
    public class CharityContainerViewModel : ViewModelBase, IValidatableObject
    {
        public CNM.Models.Charity Charity { get; set; }
        public List<Skill> SelectedSkills { get; set; }
        public List<ServiceArea> SelectedAreas { get; set; }

        public List<SkillEntity> CurrentSkills { get; set; }
        public List<ServiceAreaEntity> CurrentAreas { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (SelectedSkills == null || SelectedSkills.Count == 0)
                yield return new ValidationResult("You must select at least one skill.", new string[] { "skills" });

            if (SelectedAreas == null || SelectedAreas.Count == 0)
                yield return new ValidationResult("You must select at least one service area.", new string[] { "serviceareas" });
        }
    }
}