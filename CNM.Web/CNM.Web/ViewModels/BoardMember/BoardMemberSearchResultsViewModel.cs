using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CNM.Models;

namespace CNM.Web.ViewModels
{
    public class BoardMemberSearchResultsViewModel : ViewModelBase
    {
        public IEnumerable<CNM.Models.Charity> MatchingCharities { get; set; }
    }
}