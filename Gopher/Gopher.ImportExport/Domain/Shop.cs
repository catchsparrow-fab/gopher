using Gopher.Tools;

namespace Gopher.ImportExport.Domain
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
