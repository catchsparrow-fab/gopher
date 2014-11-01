using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gopher.ImportExport.Domain;

namespace Gopher.ImportExport.Tools
{
    public class Format
    {
        private const string DELIMITER = ",";
        private static readonly CultureInfo japaneseCulture = new CultureInfo("ja-JP");

        public static string CustomerToString(Customer customer)
        {
            return string.Join(DELIMITER, new object [] {
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
                customer.AmountPurchased,
                DtToString(customer.DateRegistered),
                customer.TimesPurchased,
                DtToString(customer.DateUpdated),
                DtToString(customer.DateFirstPurchased),
                DtToString(customer.DateLastPurchased),
                // TEMPO-VISOR DATA
                customer.TempoVisorData.CompanyCode,
                customer.TempoVisorData.Zip,
                customer.TempoVisorData.Area,
                customer.TempoVisorData.Black,
                customer.TempoVisorData.MemberRank,
                customer.TempoVisorData.Status,
                customer.TempoVisorData.MemberNumber,
                customer.TempoVisorData.DirectMailFlag,
                (int?)customer.TempoVisorData.EmailAccept,
                customer.TempoVisorData.Note,
                customer.TempoVisorData.PriceApplication,
                customer.TempoVisorData.Point,
                customer.TempoVisorData.PointDeposited,
                customer.TempoVisorData.LastPointIssued,
                DtToString(customer.TempoVisorData.LastPointIssuedDate),
                customer.TempoVisorData.LastPointUsed,
                DtToString(customer.TempoVisorData.LastPointUsedDate),
                customer.TempoVisorData.Fillers,
                (int?)customer.TempoVisorData.Operation,
                DtToString(customer.TempoVisorData.CutoutDate),
                DtToString(customer.TempoVisorData.ExpirationDate),
                DtToString(customer.TempoVisorData.LastVisitedDate)
            });
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

        public static string MergeIntoString(string[] array, int startIndex, int count)
        {
            return string.Join(" ", array.Skip(startIndex).Take(count).ToArray());
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
            if (DateTime.TryParse(s, japaneseCulture, DateTimeStyles.None, out dt))
                return dt;
            return null;
        }

        public static T? GetNullableEnum<T>(string s)
            where T: struct
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
