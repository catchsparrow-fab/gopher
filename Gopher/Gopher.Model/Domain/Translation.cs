using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gopher.Model.Abstractions;
using Gopher.Tools;

namespace Gopher.Model.Domain
{
    public class Translation : IPersistent
    {
        public int PageLabelId { get; set; }
        public int LanguageId { get; set; }
        public string LabelName { get; set; }
        public string Text { get; set; }

        public void Init(IDataReader reader)
        {
            PageLabelId = reader.GetInt32("PageLabelId");
            LanguageId = reader.GetInt32("LanguageId");
            LabelName = reader.GetString("LabelName");
            Text = reader.GetString("Translation");
        }
    }
}
