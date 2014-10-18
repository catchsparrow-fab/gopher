using System;

namespace Gopher.ImportExport.Domain
{
    // array to form a line: 
    // 0 - customer id (string)
    // 1 - shop id (string)
    // 2 - pref (string)
    // 3 - name kanji (string)
    // 4 - name kana (string)
    // 5 - sex (int)
    // 6 - dob (datetime)
    // 7 - email (string)
    // 8 - email mobile (string)
    // 9 - phone (string)
    // 10 - amount purchased (decimal)
    // 11 - date registered (datetime)
    // 12 - times purchased (int)
    // 13 - date updated (datetime)
    // 14 - date first purchased (datetime)
    // 15 - date last purchased (datetime)
    public class Customer
    {
        public string Id { get; set; }
        public string ShopId { get; set; }
        public string Prefecture { get; set; }
        public string NameKanji { get; set; }
        public string NameKana { get; set; }
        public Sex? Sex { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string EmailMobile { get; set; }
        public string Phone { get; set; }
        public decimal? AmountPurchased { get; set; }
        public DateTime? DateRegistered { get; set; }
        public int? TimesPurchased { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateFirstPurchased { get; set; }
        public DateTime? DateLastPurchased { get; set; }
    }
}
