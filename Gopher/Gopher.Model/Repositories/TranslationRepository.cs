using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gopher.Model.Abstractions;
using Gopher.Model.Tools;

namespace Gopher.Model.Repositories
{
    public class TranslationRepository : ITranslationRepository
    {
        public string GetTranslation(string label, string lang)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAll(string lang)
        {
            throw new NotImplementedException();
            //return DbHelper.GetList<
        }
    }
}
