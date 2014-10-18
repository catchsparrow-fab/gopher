using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gopher.ImportExport.Domain;
using Gopher.ImportExport.Tools;

namespace Gopher.ImportExport.Parsers
{
    public class TempoVisorParser : StandardParser
    {
        protected override Customer GetCustomer(string[] array)
        {
            return new Customer
            {
                Id = array[1],
                ShopId = array[2],
                NameKana = array[3],
                NameKanji = array[6],
                Phone = array[4],
                Sex = Format.GetSex(array[12]),
                DateOfBirth = Format.GetDateTime(array[9]),
                DateRegistered = Format.GetDateTime(array[10]),
                DateUpdated = Format.GetDateTime(array[43]),
                Email = array[20],
                EmailMobile = array[21],
                Prefecture = TempoVisorPrefectureHelper.GetPrefecture(array[7])
            };
        }

        protected override Encoding InputEncoding
        {
            get
            {
                return Encoding.GetEncoding(932); // shift-jis
            }
        }
    }
}
