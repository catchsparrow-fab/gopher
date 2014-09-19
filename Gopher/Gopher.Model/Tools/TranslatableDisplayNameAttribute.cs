using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gopher.Model.Tools
{
    public class TranslatableDisplayNameAttribute : DisplayNameAttribute
    {
        public string LabelName { get; set; }

        public TranslatableDisplayNameAttribute(string labelName)
        {
            LabelName = labelName;
        }

        public override string DisplayName
        {
            get
            {
                return TranslationHelper.Get(LabelName);
            }
        }
    }
}
