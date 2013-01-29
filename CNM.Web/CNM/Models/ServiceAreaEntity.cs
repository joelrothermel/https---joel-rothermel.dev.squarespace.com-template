using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNM.Models
{
    public class ServiceAreaEntity
    {
        public int ServiceAreaId { get; set; }
        public string ServiceAreaName { get; set; }

        public virtual ICollection<Charity> InterestedCharities { get; set; }
        public virtual ICollection<BoardMember> BoardMembersWithThisInterest { get; set; }
    }
}
