using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gopher.Model.Domain
{
    public enum Language
    {
        English = 1, Japanese = 2,

        Default = 1
    }

    public class LanguageHelper
    {
        public static string GetLanguageName(int languageId)
        {
            var language = (Language)languageId;

            switch (language)
            {
                case Language.English:
                    return "English";
                case Language.Japanese:
                    return "Japanese";
            }

            throw new ArgumentOutOfRangeException();
        }
    }
}
