using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gopher.ImportExport.Domain
{
    public struct Range<T>
        where T: struct, IComparable
    {
        public T? Min { get; set; }
        public T? Max { get; set; }
    }
}
