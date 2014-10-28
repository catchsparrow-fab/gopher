using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gopher.ImportExport.Tools
{
    public class ErrorMessage
    {
        public static string FromException(Exception ex)
        {
            return string.Format("[{0}] {1} \r\n {2}", ex.GetType().Name, ex.Message, ex.StackTrace);
        }
    }
}
