using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNM.Models
{
    public class SkillEntity
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }

        public virtual ICollection<Charity> Charities { get; set; }
        public virtual ICollection<BoardMember> BoardMembers { get; set; }
    }
}
