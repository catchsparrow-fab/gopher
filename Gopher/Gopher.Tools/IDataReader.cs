using System;

namespace Gopher.Tools
{
    public interface IDataReader
    {
        object this[int index]
        {
            get;
        }

        bool Read();
        bool NextResult();
        string GetString(string name);
        bool GetBoolean(string name);
        bool? GetNullableBoolean(string name);
        int GetInt32(string name);
        int? GetNullableInt32(string name);
        T? GetNullableEnum<T>(string name) where T : struct;
        decimal GetDecimal(string name);
        decimal? GetNullableDecimal(string name);
        DateTime GetDateTime(string name);
        DateTime? GetNullableDateTime(string name);
    }
}