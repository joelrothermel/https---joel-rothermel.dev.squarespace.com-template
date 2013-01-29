using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CNM.Web.Routing
{
    public class StronglyNamedRouteResult : ActionResult
    {
        public RouteValueDictionary RouteValues { get; protected set; }

        public StronglyNamedRouteResult()
        {
            RouteValues = new RouteValueDictionary();
        }

        public virtual StronglyNamedRouteResult AddRouteValue(string key, object value)
        {
            RouteValues.Add(key, value);

            return this;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            new RedirectToRouteResult(RouteValues).ExecuteResult(context);
        }
    }
}