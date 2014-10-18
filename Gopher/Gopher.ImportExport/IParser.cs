using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gopher.ImportExport
{
    public interface IParser
    {
        void Parse(Stream input, Stream output);
    }
}
