using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNM.Web.ViewModels.Search
{
    public class CharitySearchResultItemViewModel
    {
        public string OrganizationName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Essay { get; set; }

    }
}