using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CNM.Sql
{
    public class OutputParameter<T>
    {
        protected SqlParameter _parameter = null;

        public OutputParameter(SqlParameter parameter)
        {
            _parameter = parameter;
        }

        public T Value
        {
            get
            {
                if (_parameter.Value as DBNull == null)
                    return _parameter.Value.ConvertTo<T>();

                return default(T);
            }
        }
    }
}
