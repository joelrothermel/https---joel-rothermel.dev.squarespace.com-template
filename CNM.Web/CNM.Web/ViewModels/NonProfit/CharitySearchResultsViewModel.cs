using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CNM.Models;

namespace CNM.Web.ViewModels.NonProfit
{
    public class CharitySearchResultsViewModel : ViewModelBase
    {
        public IEnumerable<BoardMemberSearchResult> SearchResults { get; set; }
    }
}