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
            return GetList<T>(null, commandText, commandType, parameters);
        }

        public static IEnumerable<T> GetList<T>(DataAccess dataAccess, string commandText, CommandType commandType,
            params DbParameter[] parameters)
            where T : IPersistent, new()
        {
            if (dataAccess == null)
                dataAccess = DataAccess.Create();

            List<T> list = new List<T>();

            //using (dataAccess)
            //{
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
            //}

            return list;
        }

        public static T GetItem<T>(string commandText, CommandType commandType, params DbParameter[] parameters)
            where T : IPersistent, new()
        {
            return GetItem<T>(null, commandText, commandType, parameters);
        }

        public static T GetItem<T>(DataAccess dataAccess, string commandText, CommandType commandType,
            params DbParameter[] parameters)
            where T : IPersistent, new()
        {
            if (dataAccess == null)
                dataAccess = DataAccess.Create();

            //using (dataAccess)
            //{
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
            //}
            return default(T);
        }

        public static int ExecuteNonQuery(string commandText, CommandType commandType, params DbParameter[] parameters)
        {
            return ExecuteNonQuery(null, commandText, commandType, parameters);
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

            return (T) Convert.ChangeType(obj, typeof (T));
        }
    }
}