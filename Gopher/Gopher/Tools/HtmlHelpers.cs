using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gopher.Model.Tools;

namespace System.Web.Mvc
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString Translation(this HtmlHelper helper, string labelName)
        {
            var text = TranslationHelper.GetTranslation(labelName).Text;
            return new MvcHtmlString(text);
        }
    }
}