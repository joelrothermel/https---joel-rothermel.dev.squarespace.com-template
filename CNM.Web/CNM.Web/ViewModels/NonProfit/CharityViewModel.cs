using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CNM.Models;

namespace CNM.Web.ViewModels
{
    public class CharityViewModel : ViewModelBase
    {
        public Charity Charity { get; set; }
    }
}