using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNM.Sql;

namespace CNM.Security.Procedures
{
    public class LookupCharityId : SqlStoredProcedureBase
    {
        public LookupCharityId()
            : base(ConnectionStrings.Database)
        {

        }

        public virtual LookupCharityIdOutput Execute(string webLogin)
        {
            AddParameter("@WebLogin", System.Data.SqlDbType.VarChar, webLogin, 60);

            return SingleRow<LookupCharityIdOutput>();
        }
    }

    public class LookupCharityIdOutput
    {
        public string CharityId { get; set; }
    }
}
