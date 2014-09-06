namespace Gopher.Model.Abstractions.Core
{
    public interface ISingleItemRepository<TItem, TKey>
    {
        TKey Add(TItem item);
        void Update(TItem item);
        void Delete(TKey id);
        TItem GetSingle(TKey id);
    }
}
