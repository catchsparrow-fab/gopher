using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gopher.ImportExport.Tools
{
    public class ShiftJis
    {
        private static Encoding encoding = null;
        public static Encoding Encoding
        {
            get
            {
                if (encoding == null)
                    encoding = Encoding.GetEncoding(932);
                return encoding;
            }
        }
    }
}
