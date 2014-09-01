using Gopher.Model.Tools;
using SwankSpank.Domain.Abstractions;

namespace Gopher.Model.Abstractions
{
    public interface IPersistent
    {
        void Init(IDataReader reader);
    }
}