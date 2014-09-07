using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gopher.Model.Abstractions;
using SwankSpank.Domain.Abstractions;

namespace Gopher.Model.Domain
{
    public class Translation : IPersistent
    {
        public int Id { get; set; }
        public string Lang { get; set; }
        public string Label { get; set; }

        public void Init(IDataReader reader)
        {
            Id = reader.GetInt32("TranslationId");
            Lang = reader.GetString("Lang");
            Label = reader.GetString("Label");
        }
    }
}
