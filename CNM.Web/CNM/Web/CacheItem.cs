using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNM.Web
{
    public class CacheItem<TDataType>
    {
        public TDataType Object { get; set; }
        public bool WasFound { get; set; }
    }
}
