using System.Collections.Generic;
using Gopher.Tools;

namespace Gopher.ImportExport.Domain
{
    public interface IShopRepository
    {
        IEnumerable<Shop> GetAll();
        void Update(Shop shop);
        void Delete(int id);
        Shop GetSingle(int id);
        int Add(Shop shop);
    }

    public class ShopRepository : IShopRepository
    {
        public IEnumerable<Shop> GetAll()
        {
            return DbHelper.GetList<Shop>("SELECT * FROM Shops", CommandType.DynamicSql);
        }

        public void Update(Shop shop)
        {
            DbHelper.ExecuteNonQuery("UPDATE Shops SET FullName = @fullName, ShopImportedId = @importedId WHERE ShopId = @id", CommandType.DynamicSql,
                new DbParameter("fullName", shop.Name),
                new DbParameter("importedId", shop.ImportedId),
                new DbParameter("id", shop.Id));
        }

        public void Delete(int id)
        {
            DbHelper.ExecuteNonQuery("DELETE FROM Shops WHERE ShopId = @id", CommandType.DynamicSql,
                new DbParameter("id", id));
        }

        public Shop GetSingle(int id)
        {
            return DbHelper.GetItem<Shop>("SELECT * FROM Shops WHERE ShopId = @id", CommandType.DynamicSql,
                new DbParameter("id", id));
        }

        public int Add(Shop shop)
        {
            return DbHelper.ExecuteScalar<int>("INSERT INTO Shops (ShopImportedId, FullName) VALUES (@importedId, @fullName)",
                CommandType.DynamicSql,
                new DbParameter("fullName", shop.Name),
                new DbParameter("importedId", shop.ImportedId));
        }
    }
}
