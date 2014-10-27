using System;
using System.Collections.Generic;
using System.IO;
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

        public static string GenerateTempFileName()
        {
            var appDataPath = HttpContext.Current.Server.MapPath("~/App_Data");
            return Path.Combine(appDataPath, Guid.NewGuid().ToString());
        }
    }
}