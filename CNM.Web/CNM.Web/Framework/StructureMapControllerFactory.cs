using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StructureMap;

namespace CNM.Web.Framework
{
    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            try
            {
                var controller = ObjectFactory.GetInstance(controllerType) as IController;

                if (controller == null)
                    return base.GetControllerInstance(requestContext, controllerType);

                return controller;
            }
            catch
            {
                return base.GetControllerInstance(requestContext, controllerType);
            }
        }
    }
}