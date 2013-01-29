using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CNM.Sql
{
    public abstract class SqlStoredProcedureBase
    {
        protected SqlConnection _sqlConnection = null;
        protected SqlCommand _sqlCommand = null;

        public SqlStoredProcedureBase(string connectionString)
            : this(connectionString, String.Empty)
        {
        }

        public SqlStoredProcedureBase(string connectionString, string overriddenProcedureName)
        {
            _sqlConnection = new SqlConnection(connectionString);

            string procedureName = GetType().Name;

            if (procedureName.ToLower().EndsWith("procedure"))
                procedureName = procedureName.Replace("Procedure", string.Empty);

            if (!String.IsNullOrEmpty(overriddenProcedureName))
                procedureName = overriddenProcedureName;

            _sqlCommand = new SqlCommand(procedureName, _sqlConnection);
            _sqlCommand.CommandType = CommandType.StoredProcedure;
        }

        protected void AddParameter(string paramName, SqlDbType type, object value, int size = 0)
        {
            SqlParameter param = new SqlParameter(paramName, type, size);
            param.Value = value;
            param.Direction = ParameterDirection.Input;

            _sqlCommand.Parameters.Add(param);
        }

        protected OutputParameter<T> AddOutputParameter<T>(string paramName, SqlDbType type, object value, int size = 0)
        {
            SqlParameter param = new SqlParameter(paramName, type, size);
            param.Value = value;
            param.Direction = ParameterDirection.InputOutput;

            _sqlCommand.Parameters.Add(param);

            return new OutputParameter<T>(param);
        }

        protected T SingleRow<T>()
            where T : new()
        {
            T result = new T();

            using (_sqlConnection)
            {
                using (_sqlCommand)
                {
                    _sqlConnection.Open();

                    using (SqlDataReader reader = _sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            foreach (PropertyInfo property in result.GetType().GetProperties())
                            {
                                if (reader[property.Name] != DBNull.Value)
                                    property.SetValue(result, reader[property.Name], null);
                            }
                        }
                    }
                }
            }

            return result;
        }

        protected T MultipleResultSet<T>(params Type[] resultTypes) where T : new()
        {
            T result = new T();
            int currentResultSetCount = 1;

            using (_sqlConnection)
            {
                using (_sqlCommand)
                {
                    _sqlConnection.Open();

                    using (SqlDataReader reader = _sqlCommand.ExecuteReader())
                    {
                        foreach (var type in resultTypes)
                        {
                            var resultSetListType = typeof(List<>).MakeGenericType(type);

                            var list = Activator.CreateInstance(resultSetListType);

                            while (reader.Read())
                            {
                                var item = Activator.CreateInstance(type);

                                foreach (PropertyInfo property in item.GetType().GetProperties())
                                {
                                    if (reader[property.Name] != DBNull.Value)
                                        property.SetValue(item, reader[property.Name], null);
                                }

                                list.GetType().GetMethod("Add").Invoke(list, new object[] { item });
                            }

                            result.GetType().GetProperty("ResultSet" + currentResultSetCount).SetValue(result, list, null);
                            currentResultSetCount++;
                            reader.NextResult();
                        }
                    }
                }
            }
            
            return result;
        }

        protected List<T> ResultSet<T>()
            where T : new()
        {
            List<T> results = new List<T>();

            using (_sqlConnection)
            {
                using (_sqlCommand)
                {
                    _sqlConnection.Open();

                    using (SqlDataReader reader = _sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            T result = new T();

                            foreach (PropertyInfo property in result.GetType().GetProperties())
                            {
                                if (reader[property.Name] != DBNull.Value)
                                    property.SetValue(result, reader[property.Name], null);
                            }

                            results.Add(result);
                        }
                    }
                }
            }

            return results;
        }

        protected void ExecuteNonQuery()
        {
            using (_sqlConnection)
            {
                using (_sqlCommand)
                {
                    _sqlConnection.Open();

                    _sqlCommand.ExecuteNonQuery();
                }
            }
        }

        protected int ExecuteNonQueryWithReturnCode()
        {
            int returnCode = Int32.MinValue;

            using (_sqlConnection)
            {
                using (_sqlCommand)
                {
                    _sqlConnection.Open();

                    _sqlCommand.ExecuteNonQuery();

                    if (_sqlCommand.Parameters["@RETURN_VALUE"].Value != null)
                        Int32.TryParse(_sqlCommand.Parameters["@RETURN_VALUE"].Value.ToString(), out returnCode);
                }
            }

            return returnCode;
        }
    }
}
