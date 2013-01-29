using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNM.Web.ViewModels.Search
{
    public class CharitySearchResultsViewModel : ViewModelBase
    {
        public IEnumerable<SearchErrorViewModel> Errors { get; set; }
        public string Status { get; set; }
        public IEnumerable<CharitySearchResultItemViewModel> SearchResults { get; set; }

        public double MaxPageCount { get; set; }
    }
}