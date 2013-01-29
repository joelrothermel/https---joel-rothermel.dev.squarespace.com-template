using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNM.Web.ViewModels
{
    public class ViewModelBase
    {
        public string PageTitle { get; set; }
        public string PageId { get; set; }
        public string PageClass { get; set; }
        public string ContentId { get; set; }
        public string ContentClass { get; set; }

        public UserAuthenticationType UserType { get; set; }
        public bool IsLoggedIn { get; set; }

        public ViewModelBase()
        {
            PageId = "page";
            PageClass = "page";
            ContentId = "content";
            ContentClass = "content";
        }
    }
}