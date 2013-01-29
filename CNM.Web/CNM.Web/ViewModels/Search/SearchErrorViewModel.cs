using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNM.Web.ViewModels.Search
{
    public class SearchErrorViewModel
    {
        public string Name { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}