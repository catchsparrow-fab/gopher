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
                Phone = array[4],
                CellPhone = array[5],
                NameKanji = array[6],
                Prefecture = TempoVisorPrefectureHelper.GetPrefecture(array[7]),
                DateOfBirth = Format.GetDateTime(array[9]),
                DateRegistered = Format.GetDateTime(array[10]),
                Sex = Format.GetNullableEnum<Sex>(array[12]),
                Email = array[20],
                EmailMobile = array[21],
                DateUpdated = Format.GetDateTime(array[43]),
                TempoVisorData = new TempoVisorData
                {
                    CompanyCode = array[0],
                    Zip = array[8],
                    ExpirationDate = Format.GetDateTime(array[11]),
                    Area = Format.GetInt32(array[13]),
                    Black = Format.GetBoolean(array[14]),
                    MemberRank = Format.GetInt32(array[15]),
                    Status = Format.GetInt32(array[16]),
                    MemberNumber = array[17],
                    // 18 is skipped - date updated - using 43 instead
                    DirectMailFlag = Format.GetBoolean(array[19]),
                    EmailAccept = Format.GetNullableEnum<TempoVisorEmailAccept>(array[22]),
                    Note = array[23],
                    PriceApplication = Format.GetInt32(array[24]),
                    LastVisitedDate = Format.GetDateTime(array[25]),
                    Point = Format.GetInt32(array[26]),
                    PointDeposited = Format.GetInt32(array[27]),
                    LastPointIssued = Format.GetInt32(array[28]),
                    LastPointIssuedDate = Format.GetDateTime(array[29]),
                    LastPointUsed = Format.GetInt32(array[30]),
                    LastPointUsedDate = Format.GetDateTime(array[31]),
                    Fillers = Format.MergeIntoString(array, 32, 9),
                    Operation = Format.GetNullableEnum<TempoVisorOperation>(array[41]),
                    CutoutDate = Format.GetDateTime(array[42]),
                }
            };
        }

        protected override Encoding InputEncoding
        {
            get
            {
                return Encoding.GetEncoding(932); // shift-jis
            }
        }

        protected override InputFileType FileType
        {
            get { return InputFileType.TempoVisor; }
        }
    }
}
