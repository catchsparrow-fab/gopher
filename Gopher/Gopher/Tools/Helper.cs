using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gopher.Tools
{
    public class Helper
    {
        public static string ErrorMessage(Exception ex)
        {
            return string.Format("Fatal error occurred: {0}", ex.Message);
        }
    }
}