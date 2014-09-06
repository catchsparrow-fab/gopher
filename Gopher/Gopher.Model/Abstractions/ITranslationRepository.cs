using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gopher.Model.Abstractions.Core;

namespace Gopher.Model.Abstractions
{
    public interface ITranslationRepository
    {
        string GetTranslation(string label, string lang);
        IEnumerable<string> GetAll(string lang);
    }
}
