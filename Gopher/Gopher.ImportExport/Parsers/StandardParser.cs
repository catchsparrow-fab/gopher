using System.IO;
using System.Text;
using Gopher.ImportExport.Domain;
using Gopher.ImportExport.Tools;

namespace Gopher.ImportExport.Parsers
{
    public abstract class StandardParser : IParser
    {
        public void Parse(Stream input, Stream output)
        {
            using (var reader = new StreamReader(input, InputEncoding))
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

        protected virtual Encoding InputEncoding
        {
            get
            {
                return Encoding.UTF8;
            }
        }
    }
}
