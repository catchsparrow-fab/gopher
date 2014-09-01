using System;

namespace Gopher.Model.Tools
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
    }
}