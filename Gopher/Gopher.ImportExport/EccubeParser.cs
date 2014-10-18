using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gopher.ImportExport.Tools;

namespace Gopher.ImportExport
{
    public class EccubeParser : StandardParser
    {
        protected override Customer GetCustomer(string[] array)
        {
            return new Customer
            {
                Id = array[0],
                ShopId = "EC",
                NameKanji = string.Format("{0} {1}", array[1], array[2]),
                NameKana = string.Format("{0} {1}", array[3], array[4]),
                Sex = Format.GetSex(array[18]),
                DateOfBirth = Format.GetDateTime(array[20]),
                DateFirstPurchased = Format.GetDateTime(array[25]),
                DateLastPurchased = Format.GetDateTime(array[26]),
                DateRegistered = Format.GetDateTime(array[32]),
                DateUpdated = Format.GetDateTime(array[33]),
                Email = array[10],
                EmailMobile = array[11],
                Phone = string.Format("{0}{1}{2}", array[12], array[13], array[14]),
                AmountPurchased = Format.GetDecimal(array[28]),
                TimesPurchased = Format.GetInt32(array[27])
            };
        }
    }
}
