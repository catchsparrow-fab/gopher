using System;
using System.Text;
using Gopher.ImportExport.Domain;
using Gopher.ImportExport.Tools;

namespace Gopher.ImportExport.Parsers
{
    public class EccubeParser : StandardParser
    {
        private const string ECCUBE_SHOP_ID = "EC";

        protected override Customer GetCustomer(string[] array)
        {
            return new Customer
            {
                Id = array[0],
                ShopId = ECCUBE_SHOP_ID,
                NameKanji = Format.MergeIntoString(array, 1, 2),
                NameKana = Format.MergeIntoString(array, 3, 2),
                Zip = Format.MergeIntoString(array, 6, 2),
                Prefecture = array[8],
                Address = Format.MergeIntoString(array, 9, 2),
                Email = array[11],
                Phone = Format.MergeIntoString(array, 12, 3, string.Empty),
                Sex = GetSex(array[18]),
                DateOfBirth = GetDateTime(array[20]),
                Note = array[25],
                DateRegistered = GetDateTime(array[26]),
                DateUpdated = GetDateTime(array[27]),
                EccubeData = new EccubeData
                {
                    CompanyName = array[5],
                    Fax = Format.MergeIntoString(array, 15, 3, string.Empty),
                    Occupation = array[19],
                    DateFirstPurchased = GetDateTime(array[21]),
                    DateLastPurchased = GetDateTime(array[22]),
                    TimesPurchased = Format.GetInt32(array[23]),
                    ProductWarranty = Format.MergeIntoString(array, 31, 100)
                }
            };
        }

        private static Sex? GetSex(string value)
        {
            if (value == "男性") return Sex.Male;
            if (value == "女性") return Sex.Female;
            return null;
        }

        private static DateTime? GetDateTime(string value)
        {
            value = value.Replace("\"", string.Empty); // datetimes in eccube are wrapped in quotes
            return Format.GetDateTime(value);
        }

        protected override InputFileType FileType
        {
            get { return InputFileType.Eccube; }
        }
    }
}
