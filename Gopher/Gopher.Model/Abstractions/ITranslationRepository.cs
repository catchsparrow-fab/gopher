using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gopher.Model.Abstractions.Core;
using Gopher.Model.Domain;

namespace Gopher.Model.Abstractions
{
    public interface ITranslationRepository
    {
        Translation GetSingle(string label, int languageId);
        IEnumerable<Translation> GetAll(int languageId);
    }
}
