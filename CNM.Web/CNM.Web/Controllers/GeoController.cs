using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNM.Geography;

namespace CNM.Web.Controllers
{
    public class GeoController : CnmControllerBase
    {
        protected GeoProvider _geoProvider = null;

        public GeoController(GeoProvider geoProvider)
        {
            _geoProvider = geoProvider;
        }

        public ActionResult States()
        {
            var allStates = _geoProvider.GetStates().ToList();

            return Json(allStates, "text/plain", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Cities(string id)
        {
            var allCities = _geoProvider.GetCitiesFor(id);

            return Json(allCities, "text/plain", JsonRequestBehavior.AllowGet);
        }
    }
}
