using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Gopher.Model.Tools
{
    public class DataAccess
    {
        /// <summary>
        /// If automaticScope is true, this dataAccess will open and close the connection 
        /// automatically whenever ExecuteNonQuery or ExecuteScalar is called (there is no need to wrap it in a using statement).
        /// ExecuteReader will open the connection and return the reader; the connection will be closed in reader.Dispose().
        /// If automaticScope is false, connection will be opened in the constructor but will have to be closed
        /// manually by calling Close().
        /// </summary>
        /// <param name="automaticScope"></param>
        private DataAccess(bool automaticScope)
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["gopher"].ConnectionString);
            this.automaticScope = automaticScope;

            if (!automaticScope)
                connection.Open();
        }

        private bool automaticScope = false;

        public static DataAccess Create()
        {
            return new DataAccess(true);
        }

        public static DataAccess CreatePersistent()
        {
            return new DataAccess(false);
        }

        private SqlConnection connection = null;
        private SqlCommand command = null;

        //public void Dispose()
        //{
        //    //if (!automaticScope)
        //    //    connection.Close();
        //}

        public void Close()
        {
            connection.Close();
        }

        public void SetCommand(string commandText, CommandType commandType, params DbParameter[] parameters)
        {
            command = connection.CreateCommand();

            if (commandType == CommandType.StoredProc)
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = commandText;
            }
            else if (commandType == CommandType.DynamicSql)
            {
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = commandText;
            }
            else
                throw new ArgumentException();

            foreach (var item in parameters)
            {
                command.Parameters.Add(new SqlParameter(item.Name, item.Value));
            }
        }

        public DataReader ExecuteReader()
        {
            DataAccess self = null;

            if (automaticScope)
            {
                connection.Open();
                self = this;
            }

            return new DataReader(command.ExecuteReader(), self);
        }

        public bool Open { get { return connection.State != System.Data.ConnectionState.Closed; } }

        public int ExecuteNonQuery()
        {
            if (automaticScope)
                connection.Open();
            int result = command.ExecuteNonQuery();
            if (automaticScope)
                connection.Close();
            return result;
        }

        public object ExecuteScalar()
        {
            if (automaticScope)
                connection.Open();
            object result = command.ExecuteScalar();
            if (automaticScope)
                connection.Close();
            return result;
        }
    }
}