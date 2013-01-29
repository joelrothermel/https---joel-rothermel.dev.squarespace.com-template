using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNM.Web.Controllers;
using CNM.Web.Routing;

namespace CNM.Web.Framework
{
    public abstract class CnmFilterAttributeBase : ActionFilterAttribute
    {
        public ControllerRoutes RedirectTo { get; set; }

        public CnmFilterAttributeBase()
        {
            RedirectTo = new ControllerRoutes();
        }

        protected CnmControllerBase GetController(ControllerContext controllerContext)
        {
            var controller = controllerContext.Controller as CnmControllerBase;

            if (controller == null)
                throw new ArgumentException("This attribute was placed on a non-CNM controller.");

            return controller as CnmControllerBase;
        }
    }
}