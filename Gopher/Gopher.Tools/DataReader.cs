using System;
using System.Data.SqlClient;

namespace Gopher.Tools
{
    public class DataReader : IDataReader, IDisposable
    {
        private SqlDataReader reader = null;
        private DataAccess disposableParent = null;

        private static bool HasColumn(SqlDataReader dr, string columnName)
        {
            return true;
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }

        public bool NextResult()
        {
            return reader.NextResult();
        }

        public DataReader(SqlDataReader reader, DataAccess disposableParent)
        {
            this.reader = reader;
            this.disposableParent = disposableParent;
        }

        public string GetString(string name)
        {
            if (IsNull(name)) return null;

            return reader.GetString(reader.GetOrdinal(name));
        }

        public string GetStringNullable(string name)
        {
            if (HasColumn(reader, name) && !IsNull(name))
                return GetString(name);
            return null;
        }

        public int GetInt32(string name)
        {
            return reader.GetInt32(reader.GetOrdinal(name));
        }

        public decimal GetDecimal(string name)
        {
            return reader.GetDecimal(reader.GetOrdinal(name));
        }

        public decimal? GetNullableDecimal(string name)
        {
            if (HasColumn(reader, name) && !IsNull(name))
                return GetDecimal(name);
            return null;
        }

        public int? GetNullableInt32(string name)
        {
            if (HasColumn(reader, name) && !IsNull(name))
                return GetInt32(name);
            return null;
        }

        public T? GetNullableEnum<T>(string name)
            where T : struct
        {
            object value = GetNullableInt32(name);
            if (value == null) 
                return null;
            return (T)value; 
        }

        public bool? GetNullableBoolean(string name)
        {
            if (HasColumn(reader, name) && !IsNull(name))
                return reader.GetBoolean(reader.GetOrdinal(name));
            return null;
        }

        public bool GetBoolean(string name)
        {
            return reader.GetBoolean(reader.GetOrdinal(name));
        }

        public DateTime GetDateTime(string name)
        {
            return reader.GetDateTime(reader.GetOrdinal(name));
        }

        public byte GetByte(string name)
        {
            return reader.GetByte(reader.GetOrdinal(name));
        }

        public DateTime? GetNullableDateTime(string name)
        {
            if (HasColumn(reader, name) && !IsNull(name))
                return GetDateTime(name);
            return null;
        }

        private bool IsNull(string name)
        {
            return reader.IsDBNull(reader.GetOrdinal(name));
        }

        public bool Read()
        {
            return reader.Read();
        }

        public void Dispose()
        {
            reader.Dispose();
            if (disposableParent != null)
                disposableParent.Close();
        }

        public object this[int index]
        {
            get
            {
                return reader[index];
            }
        }
    }
}