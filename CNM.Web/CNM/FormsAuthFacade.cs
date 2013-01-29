using System;
using System.Web.Security;
using CNM.Security;

namespace CNM
{
    public class FormsAuthFacade
    {
        public const string COOKIE_NAME = "AUTH";

        protected CustomDataTranslator _dataTranslator = null;

        public FormsAuthFacade(CustomDataTranslator dataTranslator)
        {
            _dataTranslator = dataTranslator;
        }

        public string SignIn(string username, UserAuthenticationType type, string charityId, int? boardMemberId)
        {
            CustomUserData customUserData = new Security.CustomUserData
            {
                AuthenticationType = type,
                CharityId = charityId,
                BoardMemberId = boardMemberId
            };

            var customUserDataToken = _dataTranslator.TransformUserData(customUserData);
            
            var ticket = new FormsAuthenticationTicket(1, username, DateTime.Now, DateTime.Now.AddDays(10), true, customUserDataToken);

            return Encrypt(ticket);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        public virtual string Encrypt(FormsAuthenticationTicket authTicket)
        {
            return FormsAuthentication.Encrypt(authTicket);
        }

        public virtual FormsAuthenticationTicket Decrypt(string authTicket)
        {
            return FormsAuthentication.Decrypt(authTicket);
        }
    }
}
