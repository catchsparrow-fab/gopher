using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gopher.ImportExport.Tools;

namespace Gopher.ImportExport
{
    public abstract class StandardParser : IParser
    {
        public void Parse(Stream input, Stream output)
        {
            using (var reader = new StreamReader(input))
            using (var writer = new StreamWriter(output, Encoding.BigEndianUnicode))
            {
                reader.ReadLine(); // header

                string line = reader.ReadLine();

                while (!string.IsNullOrEmpty(line))
                {
                    var array = line.Split(',');
                    if (array.Length > 0)
                    {
                        var customer = GetCustomer(array);
                        writer.WriteLine(Format.CustomerToString(customer));
                    }
                    line = reader.ReadLine();
                }
            }
        }

        protected abstract Customer GetCustomer(string[] array);
    }
}
