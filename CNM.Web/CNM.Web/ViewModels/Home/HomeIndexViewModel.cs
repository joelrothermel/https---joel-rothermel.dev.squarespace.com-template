using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CNM.Models;

namespace CNM.Web.ViewModels.Home
{
    public class HomeIndexViewModel : ViewModelBase
    {
        public List<BoardMember> BoardMembers { get; set; }
    }
}