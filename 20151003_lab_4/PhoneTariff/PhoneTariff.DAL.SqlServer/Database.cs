using PhoneTariff.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace PhoneTariff.DAL.SqlServer
{
    public class Database : IDatabase
    {
        private string connectionString;

        public Database(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbCommand CreateCommand(string genericCommandText)
        {
            return new SqlCommand(genericCommandText);
        }

        public int DeclareParameter(DbCommand command, string name, DbType type)
        {
            if(!command.Parameters.Contains(name))
            {
                return command.Parameters.Add(new SqlParameter(name, type));
            }
            throw new ArgumentException($"Parameter {name} already defined");
        }

        public void DefineParameter(DbCommand command, string name, DbType type, object value)
        {
            int index = DeclareParameter(command, name, type);
            command.Parameters[index].Value = value;
        }


        public int ExecuteNonQuery(DbCommand cmd)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateOpenConnection();
                cmd.Connection = connection;

                return cmd.ExecuteNonQuery();
            }
            finally // is executed in case of exceptions as well 
            {
                ReleaseConnection(connection);
            }
        }

        public IDataReader ExecuteReader(DbCommand cmd)
        {
            DbConnection connection = null;
            try
            {
                connection = GetOpenConnection();
                cmd.Connection = connection;

                var behaviour = IsSharedConnection() ? CommandBehavior.Default : CommandBehavior.CloseConnection;
                return cmd.ExecuteReader(behaviour);
            }
            catch (Exception)
            {
                Releaseconnection(connection);
                throw;
            }
        }

        public void SetParameter(DbCommand command, string name, object value)
        {
            if(command.Parameters.Contains(name))
            {
                command.Parameters[name].Value = value;
            }
            throw new ArgumentException($"Parameter {name} is not defined");
        }

        #region Private 
        private DbConnection CreateOpenConnection()
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }


        private void ReleaseConnection(DbConnection connection)
        {
            throw new NotImplementedException();
        }

        private DbConnection GetOpenConnection()
        {
            return CreateOpenConnection();
        }

        private void Releaseconnection(DbConnection connection)
        {
            connection.Close();
        }

        private bool IsSharedConnection()
        {
            return false;
        }
        #endregion

    }
}
