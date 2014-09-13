using System;
using System.Collections.Generic;
using Gopher.Model.Abstractions;

namespace Gopher.Model.Tools
{
    public class DbHelper
    {
        public static IEnumerable<T> GetList<T>(string commandText, CommandType commandType, params DbParameter[] parameters)
            where T : IPersistent, new()
        {
            var dataAccess = DataAccess.Create();

            List<T> list = new List<T>();

            dataAccess.SetCommand(commandText, commandType, parameters);

            using (var reader = dataAccess.ExecuteReader())
            {
                while (reader.Read())
                {
                    T item = new T();
                    item.Init(reader);

                    list.Add(item);
                }
            }

            return list;
        }

        public static T GetItem<T>(string commandText, CommandType commandType, params DbParameter[] parameters)
            where T : IPersistent, new()
        {
            var dataAccess = DataAccess.Create();

            dataAccess.SetCommand(commandText, commandType, parameters);

            using (var reader = dataAccess.ExecuteReader())
            {
                if (reader.Read())
                {
                    T item = new T();
                    item.Init(reader);
                    return item;
                }
            }
            return default(T);
        }

        public static int ExecuteNonQuery(string commandText, CommandType commandType, params DbParameter[] parameters)
        {
            return ExecuteNonQuery(null, commandText, commandType, parameters);
        }

        /// <summary>
        /// Equivalent to calling ExecuteNonQuery() and checking the result; if result != 1 (no rows were 
        /// affected or more than one row affected), throws an exception.
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        public static void UpdateSingle(string commandText, CommandType commandType, params DbParameter[] parameters)
        {
            var rowsAffected = ExecuteNonQuery(commandText, commandType, parameters);
            if (rowsAffected != 1)
                throw new ApplicationException("Update operation was supposed to affect a single row but affected multiple or zero rows.");
        }

        public static int ExecuteNonQuery(DataAccess dataAccess, string commandText, CommandType commandType,
            params DbParameter[] parameters)
        {
            if (dataAccess == null)
                dataAccess = DataAccess.Create();

            //using (dataAccess)
            //{
            dataAccess.SetCommand(commandText, commandType, parameters);
            return dataAccess.ExecuteNonQuery();
            //}
        }

        public static DataReader ExecuteReader(string commandText, CommandType commandType, params DbParameter[] parameters)
        {
            return ExecuteReader(null, commandText, commandType, parameters);
        }

        public static DataReader ExecuteReader(DataAccess dataAccess, string commandText, CommandType commandType,
            params DbParameter[] parameters)
        {
            if (dataAccess == null)
                dataAccess = DataAccess.Create();
            dataAccess.SetCommand(commandText, commandType, parameters);
            return dataAccess.ExecuteReader();
        }

        public static T ExecuteScalar<T>(string commandText, CommandType commandType, params DbParameter[] parameters)
        {
            return ExecuteScalar<T>(null, commandText, commandType, parameters);
        }

        public static T ExecuteScalar<T>(DataAccess dataAccess, string commandText, CommandType commandType,
            params DbParameter[] parameters)
        {
            if (dataAccess == null)
                dataAccess = DataAccess.Create();
            dataAccess.SetCommand(commandText, commandType, parameters);
            var result = dataAccess.ExecuteScalar();
            return ConvertTo<T>(result);
        }

        private static T ConvertTo<T>(object obj)
        {
            if (obj == null || obj == DBNull.Value) return default(T);

            return (T)Convert.ChangeType(obj, typeof(T));
        }
    }
}