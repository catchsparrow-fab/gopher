using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gopher.ImportExport.Parsers;

namespace Gopher.ImportExport
{
    public static class Import
    {
        private enum InputFileType
        {
            Unrecognized = 0,
            Eccube = 1,
            TempoVisor = 2,
        }

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
                        case 176: 
                            result = InputFileType.Eccube;
                            break;
                    }
                }

            }

            stream.Seek(0, SeekOrigin.Begin);

            return result;
        }

        public static void Execute(Stream input, Stream output)
        {
            var parser = CreateParser(input);

            if (parser != null)
            {
                parser.Parse(input, output);
            }
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
