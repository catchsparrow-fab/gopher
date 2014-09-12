using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gopher.Model.Abstractions;
using Gopher.Model.Domain;
using Gopher.Model.Tools;

namespace Gopher.Model.Repositories
{
    public class TranslationRepository : ITranslationRepository
    {
        public Translation GetSingle(string label, int languageId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Translation> GetAll(int languageId)
        {
            throw new NotImplementedException();
            //return DbHelper.GetList<
        }
    }
}
