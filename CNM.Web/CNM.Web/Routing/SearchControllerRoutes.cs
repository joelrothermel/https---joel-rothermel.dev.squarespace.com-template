using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNM.Web.Routing
{
    public class SearchControllerRoutes
    {
        public ActionResult NonProfits()
        {
            return new StronglyNamedRouteResult()
                .AddRouteValue("controller", "search")
                .AddRouteValue("action", "nonprofits");
        }

        public ActionResult BoardMembers()
        {
            return new StronglyNamedRouteResult()
                .AddRouteValue("controller", "search")
                .AddRouteValue("action", "BoardMembers");
        }
    }
}