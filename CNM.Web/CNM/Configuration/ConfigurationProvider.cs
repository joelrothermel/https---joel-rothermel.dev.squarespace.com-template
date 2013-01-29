using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace CNM.Configuration
{
    public class ConfigurationProvider
    {
        public virtual TRequestedType GetConfigurationValueFor<TRequestedType>(string configurationKey)
        {
            return ConfigurationManager.AppSettings[configurationKey].ConvertTo<TRequestedType>();
        }

        public virtual string GetConnectionStringFor(string connectionString)
        {
            return ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;
        }
    }
}
