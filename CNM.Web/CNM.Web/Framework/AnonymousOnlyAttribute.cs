using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNM.Charities;
using CNM.Repositories;
using StructureMap;

namespace CNM.Web.Framework
{
    public class AnonymousOnlyAttribute : CnmFilterAttributeBase
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var controller = GetController(filterContext);

            if (controller.LoggedInUser != null)
            {
                var type = controller.LoggedInUser.Type;

                if (type == UserAuthenticationType.UberMegaSuperUltraUser)
                    filterContext.Result = RedirectTo.Admin.Index();
                if (type == UserAuthenticationType.Board)
                {
                    var boardMemberProvider = ObjectFactory.GetInstance<BoardMemberProfileRepository>();

                    var boardMember = boardMemberProvider.GetBoardMember(controller.LoggedInUser.BoardMemberId.Value);

                    if (boardMember == null)
                    {
                        filterContext.Result = RedirectTo.BoardMember.New();
                    }
                    else
                    {
                        filterContext.Result = RedirectTo.Search.NonProfits();
                    }
                }
                else if (type == UserAuthenticationType.Charity)
                {
                    var charityProvider = ObjectFactory.GetInstance<CharityProvider>();

                    var charity = charityProvider.GetCharityFor(controller.LoggedInUser.CharityId);

                    if (charity == null)
                    {
                        filterContext.Result = RedirectTo.NonProfit.New();
                    }
                    else
                    {
                        filterContext.Result = RedirectTo.Search.BoardMembers();
                    }
                }
            }
        }
    }
}