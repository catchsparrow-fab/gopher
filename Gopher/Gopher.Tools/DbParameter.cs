using System;
using System.Collections.Generic;

namespace Gopher.Tools
{
    public class DbParameter
    {
        public string Name
        {
            get;
            set;
        }

        public object Value
        {
            get;
            set;
        }

        public DbParameter(string name, object obj)
        {
            this.Name = name;
            if (obj == null)
                this.Value = DBNull.Value;
            else
                this.Value = obj;
        }

        public static DbParameter Null(string name)
        {
            return new DbParameter(name, null);
        }

        public static DbParameter Collection<T>(string name, IEnumerable<T> collection)
        {
            return new DbParameter(name, DbTools.EnumerableToDatatable(collection, i => new object[] { i }, "c"));
        }
    }
}