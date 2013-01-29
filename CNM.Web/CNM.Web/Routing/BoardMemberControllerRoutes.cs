using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNM.Web.Routing
{
    public class BoardMemberControllerRoutes
    {
        public virtual ActionResult New()
        {
            return new StronglyNamedRouteResult()
                .AddRouteValue("controller", "BoardMember")
                .AddRouteValue("action", "new");
        }

        public virtual ActionResult Edit()
        {
            return new StronglyNamedRouteResult()
                .AddRouteValue("controller", "BoardMember")
                .AddRouteValue("action", "edit");
        }
    }
}