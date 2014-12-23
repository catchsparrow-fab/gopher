using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gopher.Tools
{
    public class DbTools
    {
        public static DataTable EnumerableToDatatable<T>(IEnumerable<T> enumerable, Func<T, object[]> desc, params string[] columnNames)
        {
            var dt = new DataTable();
            foreach (var c in columnNames)
                dt.Columns.Add(c);

            foreach (var item in enumerable)
            {
                dt.Rows.Add(desc(item));
            }

            return dt;
        }

        /// <summary>
        /// Splits the value by commas and returns an array of integers
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DbParameter StringToInts(string parameterName, string value)
        {
            IEnumerable<int> collection = new List<int>();

            if (!string.IsNullOrEmpty(value))
            {
                collection = from s in value.Split(',') select Convert.ToInt32(s);
            }

            return DbParameter.Collection(parameterName, collection);
        }
    }
}
