using System.Collections.Generic;

namespace Gopher.Model.Abstractions.Core
{
    public interface IListRepository<T>
    {
        IEnumerable<T> GetAll();
    }
}
