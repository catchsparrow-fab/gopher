namespace Gopher.Model.Abstractions.Core
{
    public interface ISingleItemRepository<TItem, TKey>
    {
        int Add(TItem item);
        void Update(TItem item);
        void Delete(TKey id);
        TItem GetSingle(TKey id);
    }
}
