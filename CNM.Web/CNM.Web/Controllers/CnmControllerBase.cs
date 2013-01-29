using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNM.Security;
using CNM.Web.Framework;
using CNM.Web.Routing;
using StructureMap;

namespace CNM.Web.Controllers
{
    [ViewModelBasePopulator]
    public abstract class CnmControllerBase : Controller
    {
        public ControllerRoutes RedirectTo { get; set; }

        private LoggedInUser _loggedInUser;
        public LoggedInUser LoggedInUser
        {
            get
            {
                if (_loggedInUser != null)
                    return _loggedInUser;

                if (Request.Cookies[FormsAuthFacade.COOKIE_NAME] == null)
                    return null;

                var formsFacade = ObjectFactory.GetInstance<FormsAuthFacade>();

                var ticket = formsFacade.Decrypt(Request.Cookies[FormsAuthFacade.COOKIE_NAME].Value);
                _loggedInUser = new LoggedInUser();
                _loggedInUser.Name = ticket.Name;

                CustomDataTranslator translator = new CustomDataTranslator();
                var userData = translator.TransformUserData(ticket.UserData);

                _loggedInUser.Type = userData.AuthenticationType;
                _loggedInUser.CharityId = userData.CharityId;
                _loggedInUser.BoardMemberId = userData.BoardMemberId;

                return _loggedInUser;
            }
        }

        public CnmControllerBase()
        {
            RedirectTo = new ControllerRoutes();
        }
    }
}