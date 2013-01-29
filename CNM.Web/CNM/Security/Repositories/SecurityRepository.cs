using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNM.Security.Procedures;

namespace CNM.Security.Repositories
{
    public class SecurityRepository
    {
        public virtual string GetCharityIdForLogin(string webLogin)
        {
            LookupCharityId procedure = new LookupCharityId();
            return procedure.Execute(webLogin).CharityId;
        }
    }
}
