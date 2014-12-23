using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gopher.ImportExport.Domain
{
    public class CustomerFilter
    {
        public string CustomerId { get; set; }
        public Sex[] Sex { get; set; }
        public Range<DateTime> DateOfBirth { get; set; }
        public int? Page { get; set; }
        public int? MonthOfBirth { get; set; }
        public string NameKanji { get; set; }
        public string NameKana { get; set; }
        public string Email { get; set; }
        public string EmailMobile { get; set; }
        public string Phone { get; set; }
        public Range<int> TimesPurchased { get; set; }
        public Range<DateTime> DateRegistered { get; set; }
        public Range<DateTime> DateUpdated { get; set; }  
        public Range<DateTime> DateFirstPurchased { get; set; }  
        public Range<DateTime> DateLastPurchased { get; set; }
        public string ProductWarranty { get; set; }
        public TempoVisorEmailAccept? TV_EmailAccept { get; set; }
        public EccubeEmailTarget? EC_EmailTarget { get; set; }
        public string Prefecture { get; set; }
        public string Shops { get; set; }
        public int Count { get; set; }
        public EccubeSubscriptionType? EC_SubscriptionType { get; set; }
        public ExtractPattern? ExtractPattern { get; set; }

        public CustomerFilter()
        {
            DateOfBirth = new Range<DateTime>();
            TimesPurchased = new Range<int>();
            Page = 1;
            Sex = new Sex[0];
            Count = 50;
        }
    }
}
