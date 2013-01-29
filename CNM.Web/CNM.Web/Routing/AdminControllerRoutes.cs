using System;
using System.Web.Mvc;

namespace CNM.Web.Routing
{
    public class AdminControllerRoutes
    {
        public ActionResult Index()
        {
            return new StronglyNamedRouteResult()
                .AddRouteValue("controller", "admin")
                .AddRouteValue("action", "index");
        }
    }
}