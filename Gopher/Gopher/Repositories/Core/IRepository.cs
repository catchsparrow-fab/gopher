namespace Gopher.Repositories.Core
{
    public interface IRepository<T> : ISingleItemRepository<T>, IListRepository<T>
    {
    }
}
