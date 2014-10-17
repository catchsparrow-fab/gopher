using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gopher.ImportExport
{
    public class Import
    {
        public static void Eccube(Stream input, Stream output)
        {
            using (var reader = new StreamReader(input))
            using (var writer = new StreamWriter(output, Encoding.BigEndianUnicode))
            {
                reader.ReadLine(); // header

                string line = reader.ReadLine();

                while (!string.IsNullOrEmpty(line))
                {
                    var array = line.Split(',');
                    if (array.Length > 0)
                    {
                        var customer = GetCustomerFromEccube(array);
                        writer.WriteLine(CustomerToString(customer));
                    }
                    line = reader.ReadLine();
                }
            }
        }

        private const string DELIMITER = ",";

        private static string CustomerToString(Customer customer)
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
                DtToString(customer.DateLastPurchased)
            });
        }

        private static string DtToString(DateTime? dt)
        {
            if (dt == null) return string.Empty;

            return dt.Value.ToString("d");
        }

        private static Customer GetCustomerFromEccube(string[] array)
        {
            return new Customer
            {
                Id = array[0],
                ShopId = "EC",
                NameKanji = string.Format("{0} {1}", array[1], array[2]),
                NameKana = string.Format("{0} {1}", array[3], array[4]),
                Sex = GetSex(array[18]),
                DateOfBirth = GetDateTime(array[20]),
                DateFirstPurchased = GetDateTime(array[25]),
                DateLastPurchased = GetDateTime(array[26]),
                DateRegistered = GetDateTime(array[32]),
                DateUpdated = GetDateTime(array[33]),
            };
        }

        private static Sex? GetSex(string s)
        {
            int value;
            if (int.TryParse(s, out value))
                return (Sex)value;
            return null;
        }

        private static readonly CultureInfo japaneseCulture = new CultureInfo("ja-JP");

        private static DateTime? GetDateTime(string s)
        {
            DateTime dt;
            if (DateTime.TryParse(s, japaneseCulture, DateTimeStyles.None, out dt))
                return dt;
            return null;
        }

        public static void TempoVisor(Stream input)
        {
             
        }
    }
}
