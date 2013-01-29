using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CNM.Models;

namespace CNM.Web.Mappers
{
    public class SkillsMapper
    {
        public virtual ICollection<SkillEntity> MapSkills(IEnumerable<Skill> skills)
        {
            return skills.Select(x => new SkillEntity() { SkillId = (int)x, SkillName = x.ToString() }).ToList();
        }
    }
}