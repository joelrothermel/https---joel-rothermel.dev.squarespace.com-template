using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CNM.Models;

namespace CNM.Web.ViewModels.Search
{
    public class BoardMemberSearchResultsViewModel
    {
        public IEnumerable<SearchErrorViewModel> Errors { get; set; }
        public string Status { get; set; }
        public IEnumerable<BoardMemberSearchResultItemViewModel> SearchResults { get; set; }

        public double MaxPageCount { get; set; }
    }
}