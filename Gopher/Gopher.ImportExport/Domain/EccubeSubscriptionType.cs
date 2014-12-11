using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gopher.ImportExport.Domain
{
    public enum EccubeSubscriptionType
    {
        None = 0,
        PlainText = 1,
        Html = 2,
        HtmlOrText = 3
    }

    public static class EccubeSubscriptionTypeHelper
    {
        private const string PlainText = "テキストメール";
        private const string Html = "HTMLメール";
        private const string None = "希望しない";

        public static EccubeSubscriptionType? FromString(string s)
        {
            if (s == PlainText) return EccubeSubscriptionType.PlainText;
            if (s == Html) return EccubeSubscriptionType.Html;
            if (s == None) return EccubeSubscriptionType.None;

            return null;
        }
    }
}
