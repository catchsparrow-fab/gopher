using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gopher.Tools;

namespace Gopher.Model.Domain
{
    public class Shop : IPersistent
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int ImportedId { get; set; }

        public void Init(IDataReader reader)
        {
            Name = reader.GetString("FullName");
            Id = reader.GetInt32("ShopId");
            ImportedId = reader.GetInt32("ShopImportedId");
        }
    }
}
