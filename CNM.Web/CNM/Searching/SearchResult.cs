using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNM.Searching
{
    public class SearchResult<T>
    {
        public int Page { get; set; }
        public IEnumerable<T> SearchIds { get; set; }
        public double MaxNumberOfPages { get; set; }
    }
}
