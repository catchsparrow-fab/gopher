using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gopher.Tools;

namespace Gopher.Model.Repositories
{
    public interface IPrefectureRepository
    {
        IEnumerable<string> GetAll();
    }

    public class PrefectureRepository : IPrefectureRepository
    {
        public IEnumerable<string> GetAll()
        {
            return DbHelper.GetPrimitivesList<string>("GetPrefectures", CommandType.StoredProc);
        }
    }
}
