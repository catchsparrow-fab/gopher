namespace Gopher.Model.Abstractions.Core
{
    public interface IRepository<T> : ISingleItemRepository<T>, IListRepository<T>
    {
    }
}
