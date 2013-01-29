using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNM.Models;
using CNM.Sql;

namespace CNM.Geography.Repositories
{
    public class GeoRepository
    {
        public virtual ZipCode GetZipCode(string zipCode)
        {
            using (var context = new SqlDataContext())
            {
                return context.Zips.FirstOrDefault(x => x.Zip == zipCode);
            }
        }

        public IEnumerable<string> GetCitiesFor(string state)
        {
            using (var context = new SqlDataContext())
            {
                return context.Zips.Where(z => z.State == state).Select(z => z.City).ToList();
            }
        }

        public IEnumerable<string> GetStates()
        {
            using (var context = new SqlDataContext())
            {
                return context.Zips.Select(z => z.State).Distinct().ToList();
            }
        }
    }
}
