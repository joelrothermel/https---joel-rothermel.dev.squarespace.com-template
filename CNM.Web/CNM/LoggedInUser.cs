using System;

namespace CNM
{
    public class LoggedInUser
    {
        public string Name { get; set; }
        public UserAuthenticationType Type { get; set; }
        public string CharityId { get; set; }
        public int? BoardMemberId { get; set; }
    }
}
