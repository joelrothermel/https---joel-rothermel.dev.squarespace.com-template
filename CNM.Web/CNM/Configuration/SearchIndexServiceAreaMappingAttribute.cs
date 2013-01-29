using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNM.Models;

namespace CNM.Configuration
{
    public class SearchIndexServiceAreaMappingAttribute : System.Attribute
    {
        public ServiceArea RelatedArea { get; protected set; }

        public SearchIndexServiceAreaMappingAttribute(ServiceArea relatedArea)
        {
            RelatedArea = relatedArea;
        }
    }
}
