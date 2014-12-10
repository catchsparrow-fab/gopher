using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gopher.ImportExport.Domain;
using Gopher.Tools;

namespace Gopher.ImportExport.Tools
{
    public class Format
    {
        private const string DELIMITER = "\t";
        private const string EXPORT_DELIMITER = ",";
        private static readonly CultureInfo japaneseCulture = new CultureInfo("ja-JP");

        private static string StringInQuotes(string s)
        {
            return string.Format("\"{0}\"", s);
        }

        /// <summary>
        /// To be used in export (generating csv file).
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static string ExportCustomerToString(Customer customer)
        {
            return string.Join(EXPORT_DELIMITER, new object[] {
                (int)customer.ImportedFrom,
                customer.Id,
                customer.ShopName,
                StringInQuotes(customer.Prefecture),
                StringInQuotes(customer.NameKanji),
                StringInQuotes(customer.NameKana),
                (int?)customer.Sex,
                DtToString(customer.DateOfBirth),
                customer.Email,
                customer.EmailMobile,
                customer.Phone,
                DtToString(customer.DateRegistered),
                DtToString(customer.DateUpdated),
                customer.Zip,
                customer.CellPhone,
                customer.Note,
                StringInQuotes(customer.Address),
                customer.PointBalance,
                // TEMPO-VISOR DATA
                customer.TempoVisorData.CompanyCode,
                customer.TempoVisorData.Area,
                customer.TempoVisorData.Black,
                customer.TempoVisorData.MemberRank,
                customer.TempoVisorData.Status,
                customer.TempoVisorData.MemberNumber,
                customer.TempoVisorData.DirectMailFlag,
                (int?)customer.TempoVisorData.EmailAccept,
                customer.TempoVisorData.PriceApplication,
                customer.TempoVisorData.PointDeposited,
                customer.TempoVisorData.LastPointIssued,
                DtToString(customer.TempoVisorData.LastPointIssuedDate),
                customer.TempoVisorData.LastPointUsed,
                DtToString(customer.TempoVisorData.LastPointUsedDate),
                customer.TempoVisorData.Fillers,
                (int?)customer.TempoVisorData.Operation,
                DtToString(customer.TempoVisorData.CutoutDate),
                DtToString(customer.TempoVisorData.ExpirationDate),
                DtToString(customer.TempoVisorData.LastVisitedDate),
                // TEMPO-VISOR DATA
                customer.EccubeData.CompanyName,
                customer.EccubeData.Fax,
                customer.EccubeData.Occupation,
                DtToString(customer.EccubeData.DateFirstPurchased),
                DtToString(customer.EccubeData.DateLastPurchased),
                customer.EccubeData.TimesPurchased,
                customer.EccubeData.ProductWarranty,
                customer.EccubeData.Deleted,
                (int?)customer.EccubeData.SubscriptionType,
                (int?)customer.EccubeData.EmailTarget
            });
        }

        /// <summary>
        /// To be used in bulk import. 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static string CustomerToString(Customer customer)
        {
            return string.Join(DELIMITER, new object[] {
                (int)customer.ImportedFrom,
                customer.Id,
                customer.ShopId,
                customer.Prefecture,
                customer.NameKanji,
                customer.NameKana,
                (int?)customer.Sex,
                DtToString(customer.DateOfBirth),
                customer.Email,
                customer.EmailMobile,
                customer.Phone,
                DtToString(customer.DateRegistered),
                DtToString(customer.DateUpdated),
                customer.Zip,
                customer.CellPhone,
                customer.Note,
                customer.Address,
                customer.PointBalance,
                // TEMPO-VISOR DATA
                customer.TempoVisorData.CompanyCode,
                customer.TempoVisorData.Area,
                customer.TempoVisorData.Black,
                customer.TempoVisorData.MemberRank,
                customer.TempoVisorData.Status,
                customer.TempoVisorData.MemberNumber,
                customer.TempoVisorData.DirectMailFlag,
                (int?)customer.TempoVisorData.EmailAccept,
                customer.TempoVisorData.PriceApplication,
                customer.TempoVisorData.PointDeposited,
                customer.TempoVisorData.LastPointIssued,
                DtToString(customer.TempoVisorData.LastPointIssuedDate),
                customer.TempoVisorData.LastPointUsed,
                DtToString(customer.TempoVisorData.LastPointUsedDate),
                customer.TempoVisorData.Fillers,
                (int?)customer.TempoVisorData.Operation,
                DtToString(customer.TempoVisorData.CutoutDate),
                DtToString(customer.TempoVisorData.ExpirationDate),
                DtToString(customer.TempoVisorData.LastVisitedDate),
                // TEMPO-VISOR DATA
                customer.EccubeData.CompanyName,
                customer.EccubeData.Fax,
                customer.EccubeData.Occupation,
                DtToString(customer.EccubeData.DateFirstPurchased),
                DtToString(customer.EccubeData.DateLastPurchased),
                customer.EccubeData.TimesPurchased,
                customer.EccubeData.ProductWarranty,
                customer.EccubeData.Deleted,
                (int?)customer.EccubeData.SubscriptionType,
                (int?)customer.EccubeData.EmailTarget
            });
        }

        public static string[] GetHeaders()
        {
            return new[] {
                "imported_from",
                "id",
                "shop_name",
                "prefecture",
                "name_kanji",
                "name_kana",
                "sex",
                "date_of_birth",
                "email",
                "email_mobile",
                "phone",
                "date_registered",
                "date_updated",
                "zip",
                "cellphone",
                "note",
                "address",
                "point_balance",
                "tv_company_code",
                "tv_area",
                "tv_black",
                "tv_member_rank",
                "tv_status",
                "tv_member_num",
                "tv_mail_flag",
                "tv_email_accept",
                "tv_price_appl",
                "tv_point_dep",
                "tv_point",
                "tv_point_date",
                "tv_point_used",
                "tv_point_u_date",
                "tv_fillers",
                "tv_operation",
                "tv_cutout_date",
                "tv_exp_date",
                "tv_visited_date",
                "ec_company_name",
                "ec_fax",
                "ec_occupation",
                "ec_f_buy_date",
                "ec_l_buy_date",
                "ec_times",
                "ec_warranty",
                "ec_deleted",
                "ec_subscr_type",
                "ec_email_target"
            };
        }

        private static string DtToString(DateTime? dt)
        {
            if (dt == null) return string.Empty;

            return dt.Value.ToString("yyyyMMdd");
        }

        public static int? GetInt32(string s)
        {
            int value;
            if (int.TryParse(s, out value))
                return value;
            return null;
        }

        public static bool? GetBoolean(string s)
        {
            bool value;
            if (bool.TryParse(s, out value))
                return value;
            return null;
        }

        public static string MergeIntoString(string[] array, int startIndex, int count, string delimiter = " ")
        {
            return string.Join(delimiter, array.Skip(startIndex).Take(count).ToArray().Where(s => !string.IsNullOrWhiteSpace(s)));
        }

        public static decimal? GetDecimal(string s)
        {
            decimal value;
            if (decimal.TryParse(s, out value))
                return value;
            return null;
        }

        public static DateTime? GetDateTime(string s)
        {
            DateTime dt;
            if (DateTime.TryParse(s, japaneseCulture, DateTimeStyles.None, out dt) && dt.Year > 1753)
            {
                return dt;
            }
            return null;
        }

        public static T? GetNullableEnum<T>(string s)
            where T : struct
        {
            int value;
            if (int.TryParse(s, out value))
            {
                object obj = value;
                return (T)obj;
            }
            return null;
        }
    }
}
