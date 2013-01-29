using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNM.Web.Routing
{
    public class ControllerRoutes
    {
        public NonProfitControllerRoutes NonProfit { get; set; }
        public BoardMemberControllerRoutes BoardMember { get; set; }
        public SearchControllerRoutes Search { get; set; }
        public AccountControllerRoutes Account { get; set; }
        public AdminControllerRoutes Admin { get; set; }

        public ControllerRoutes()
        {
            NonProfit = new NonProfitControllerRoutes();
            BoardMember = new BoardMemberControllerRoutes();
            Search = new SearchControllerRoutes();
            Account = new AccountControllerRoutes();
            Admin = new AdminControllerRoutes();
        }
    }
}