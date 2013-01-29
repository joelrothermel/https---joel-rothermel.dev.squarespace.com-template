using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CNM.Models
{
    public class SearchCriteria
    {
        public virtual IEnumerable<Skill> Skills { get; set; }
        public virtual IEnumerable<ServiceArea> ServiceAreas { get; set; }
        public virtual string State { get; set; }
        public virtual string City {get;set;}
        public virtual string PostalCode {get;set;}
        public virtual bool IsBoardMember { get; set; }
    }
}
