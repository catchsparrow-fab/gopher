using System.IO;

namespace Gopher.ImportExport.Parsers
{
    public interface IParser
    {
        ParseResults Parse(Stream input, Stream output);
    }
}
