using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNM.Web.Controllers;
using CNM.Web.Routing;

namespace CNM.Web.Framework
{
    public class RequiresAuthenticationAttribute : CnmFilterAttributeBase
    {
        public UserAuthenticationType ValidRole { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var controller = GetController(filterContext);

            var userInfo = controller.LoggedInUser;

            if (userInfo == null)
            {
                filterContext.Result = RedirectTo.Account.Login();
            }
            else
            {
                if (userInfo.Type == UserAuthenticationType.UberMegaSuperUltraUser)
                    return;

                if (ValidRole == UserAuthenticationType.Charity && userInfo.Type == UserAuthenticationType.Board)
                    filterContext.Result = RedirectTo.Search.BoardMembers();
                else if (ValidRole == UserAuthenticationType.Board && userInfo.Type == UserAuthenticationType.Charity)
                    filterContext.Result = RedirectTo.Search.NonProfits();
            }
        }
    }
}