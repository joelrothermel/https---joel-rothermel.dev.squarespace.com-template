using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNM.Web.ViewModels;

namespace CNM.Web.Framework
{
    public class ViewModelBasePopulatorAttribute : CnmFilterAttributeBase
    {
        public override void OnActionExecuted(System.Web.Mvc.ActionExecutedContext filterContext)
        {
            var controller = GetController(filterContext);

            if (filterContext.Result is ViewResult)
            {
                var result = filterContext.Result as ViewResult;

                var model = result.Model as ViewModelBase;

                if (model != null)
                {
                    var loginData = controller.LoggedInUser;

                    model.IsLoggedIn = loginData != null;

                    if (model.IsLoggedIn)
                    {
                        model.UserType = loginData.Type;
                    }
                }
            }
        }
    }
}