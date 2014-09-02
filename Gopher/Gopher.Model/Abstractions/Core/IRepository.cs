namespace Gopher.Model.Abstractions.Core
{
    public interface IRepository<TItem, TKey> : 
        ISingleItemRepository<TItem, TKey>, IListRepository<TItem>
    {
    }
}
