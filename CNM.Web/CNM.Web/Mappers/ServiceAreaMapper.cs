using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CNM.Models;

namespace CNM.Web.Mappers
{
    public class ServiceAreaMapper
    {
        public virtual ICollection<ServiceAreaEntity> MapServiceAreas(IEnumerable<ServiceArea> services)
        {
            return services.Select(x => new ServiceAreaEntity() { ServiceAreaId = (int)x, ServiceAreaName = x.ToString() }).ToList();
        }
    }
}