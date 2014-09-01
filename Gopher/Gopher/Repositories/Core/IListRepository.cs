using System.Collections.Generic;

namespace Gopher.Repositories.Core
{
    public interface IListRepository<T>
    {
        IEnumerable<T> GetAll();
    }
}
