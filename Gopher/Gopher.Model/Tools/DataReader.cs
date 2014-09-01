using System;
using System.Data.SqlClient;
using SwankSpank.Domain.Abstractions;

namespace Gopher.Model.Tools
{
    public class DataReader : IDataReader, IDisposable
    {
        private SqlDataReader reader = null;
        private DataAccess disposableParent = null;

        private static bool HasColumn(SqlDataReader dr, string columnName)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }

        public DataReader(SqlDataReader reader, DataAccess disposableParent)
        {
            this.reader = reader;
            this.disposableParent = disposableParent;
        }

        public string GetString(string name)
        {
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

        public DateTime? GetDateTimeNullable(string name)
        {
            if (HasColumn(reader, name) && !IsNull(name))
                return GetDateTime(name);
            return null;
        }

        public int? GetInt32Nullable(string name)
        {
            if (HasColumn(reader, name) && !IsNull(name))
                return GetInt32(name);
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