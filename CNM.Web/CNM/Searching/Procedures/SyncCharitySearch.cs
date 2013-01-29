using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNM.Sql;

namespace CNM.Searching.Procedures
{
    public class SyncCharitySearch : SqlStoredProcedureBase
    {
        public SyncCharitySearch()
            : base(ConnectionStrings.Database)
        {

        }

        public virtual void Execute(string charityId)
        {
            AddParameter("@CharityId", System.Data.SqlDbType.VarChar, charityId, 12);

            ExecuteNonQuery();
        }
    }
}
