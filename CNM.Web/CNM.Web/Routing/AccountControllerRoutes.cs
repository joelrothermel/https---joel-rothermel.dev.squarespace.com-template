using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNM.Web.Routing
{
    public class AccountControllerRoutes
    {
        public ActionResult Login()
        {
            return new StronglyNamedRouteResult()
                .AddRouteValue("controller", "account")
                .AddRouteValue("action", "login");
        }
    }
}