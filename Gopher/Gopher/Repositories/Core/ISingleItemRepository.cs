namespace Gopher.Repositories.Core
{
    public interface ISingleItemRepository<T>
    {
        int Add(T item);
        void Update(T item);
        void Delete(int id);
    }
}
