using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNM.Security
{
    public class CustomUserData
    {
        public UserAuthenticationType AuthenticationType { get; set; }
        public string CharityId { get; set; }
        public int? BoardMemberId { get; set; }
    }
}
