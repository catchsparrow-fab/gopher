using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gopher.Tools;

namespace Gopher.ImportExport.Domain
{
    public class EccubeData : IPersistent
    {
        public string CompanyName { get; set; }
        public string Fax { get; set; }
        public string Occupation { get; set; }
        public DateTime? DateFirstPurchased { get; set; }
        public DateTime? DateLastPurchased { get; set; }
        public int? TimesPurchased { get; set; }
        public string ProductWarranty { get; set; }
        public bool? Deleted { get; set; }
        public EccubeSubscriptionType? SubscriptionType { get; set; }
        public EccubeEmailTarget? EmailTarget { get; set; }

        public void Init(IDataReader reader)
        {
            CompanyName = reader.GetString("EC_CompanyName");
            Fax = reader.GetString("EC_Fax");
            Occupation = reader.GetString("EC_Occupation");
            DateFirstPurchased = reader.GetNullableDateTime("EC_DateFirstPurchased");
            DateLastPurchased = reader.GetNullableDateTime("EC_DateLastPurchased");
            TimesPurchased = reader.GetNullableInt32("EC_TimesPurchased");
            ProductWarranty = reader.GetString("EC_ProductWarranty");
            Deleted = reader.GetNullableBoolean("EC_Deleted");
            SubscriptionType = reader.GetNullableEnum<EccubeSubscriptionType>("EC_SubscriptionType");
            EmailTarget = reader.GetNullableEnum<EccubeEmailTarget>("EC_EmailTarget");
        }
    }
}
