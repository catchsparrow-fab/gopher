using System;
using System.IO;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using Gopher.ImportExport.Domain;
using Gopher.ImportExport.Tools;

namespace Gopher.ImportExport.Parsers
{
    public abstract class StandardParser : IParser
    {
        public ParseResults Parse(Stream input, Stream output)
        {
            var result = new ParseResults();

            try
            {
                result.FileSize = input.Length;
                result.FileType = FileType;
                //using (var reader = new StreamReader(input, InputEncoding))
                using (var reader = new CsvParser(new StreamReader(input, InputEncoding)))
                using (var writer = new StreamWriter(output, Encoding.BigEndianUnicode))
                {
                    var array = reader.Read(); // header
                    array = reader.Read();

                    while (array != null)
                    {
                        result.RowsInFile += 1;
                        var customer = GetCustomer(array);
                        writer.WriteLine(Format.CustomerToString(customer));
                        array = reader.Read();
                    }
                }

                result.Status = ParseStatus.Success;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ErrorMessage.FromException(ex);
            }

            return result;
        }

        protected abstract Customer GetCustomer(string[] array);
        protected abstract InputFileType FileType { get; }

        protected virtual Encoding InputEncoding
        {
            get
            {
                return Encoding.GetEncoding(932); // shift-jis
            }
        }
    }
}
