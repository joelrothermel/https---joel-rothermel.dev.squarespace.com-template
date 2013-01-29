using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNM.Configuration;

namespace CNM.Sql
{
    public class ConnectionStrings
    {
        public static string Database
        {
            get
            {
                var configurationProvider = new ConfigurationProvider();
                return configurationProvider.GetConnectionStringFor(ConnectionStringKey.Default);
            }
        }
    }
}
