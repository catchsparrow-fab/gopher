using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gopher.ImportExport.Parsers;
using Gopher.ImportExport.Tools;
using Gopher.Tools;

namespace Gopher.ImportExport
{
    public static class Import
    {
        private static InputFileType DetermineFileType(Stream stream)
        {
            var result = InputFileType.Unrecognized;

            var reader = new StreamReader(stream, Encoding.UTF8, true, 1024, true);
            {
                var line = reader.ReadLine();
                if (line != null)
                {
                    var array = line.Split(',');

                    switch (array.Length)
                    {
                        case 44: 
                            result = InputFileType.TempoVisor;
                            break;
                        case 131: 
                            result = InputFileType.Eccube;
                            break;
                    }
                }

            }

            stream.Seek(0, SeekOrigin.Begin);

            return result;
        }

        public static ParseResults GenerateBulkInsertFile(Stream input, Stream output)
        {
            var parser = CreateParser(input);

            if (parser != null)
            {
                return parser.Parse(input, output);
            }

            return new ParseResults()
            {
                ErrorMessage = "Invalid file format (#20).",
                Status = ParseStatus.Error
            };
        }

        public static BulkInsertResults BulkInsert(string fileName, InputFileType inputType)
        {
            var result = new BulkInsertResults();
            result.Status = BulkInsertStatus.Success;

            try
            {
                result.RowsAffected = DbHelper.ExecuteScalar<int>("UploadData", CommandType.StoredProc,
                    new DbParameter("fileName", fileName),
                    new DbParameter("inputType", (int)inputType));
            }
            catch (Exception ex)
            {
                result.Status = BulkInsertStatus.Error;
                result.ErrorMessage = ErrorMessage.FromException(ex);
            }

            return result;
        }

        private static IParser CreateParser(Stream stream)
        {
            switch (DetermineFileType(stream))
            {
                case InputFileType.Eccube:
                    return new EccubeParser();
                case InputFileType.TempoVisor:
                    return new TempoVisorParser();
                default:
                    return null;
            }
        }
    }
}
