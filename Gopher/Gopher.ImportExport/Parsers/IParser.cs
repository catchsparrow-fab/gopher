using System.IO;

namespace Gopher.ImportExport.Parsers
{
    public interface IParser
    {
        void Parse(Stream input, Stream output);
    }
}
