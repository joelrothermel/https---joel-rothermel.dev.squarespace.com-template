using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNM.Models;

namespace CNM.Configuration
{
    public class SearchIndexSkillMappingAttribute : Attribute
    {
        public Skill RelatedSkill { get; set; }

        public SearchIndexSkillMappingAttribute(Skill relatedSkill)
        {
            RelatedSkill = relatedSkill;
        }
    }
}
