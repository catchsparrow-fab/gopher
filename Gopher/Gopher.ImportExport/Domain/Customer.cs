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
    // 10 - date registered (datetime)
    // 11 - date updated (datetime)
    // 12	Zip	string,
    // 13   CellPhone string,
    // 14	Note	string
    // 15   Address string
    // TEMPO-VISOR DATA
    //	16	CompanyCode	string
    //	17	Area	int?
    //	18	Black	bool?
    //	19	MemberRank	int?
    //	20	Status	int?
    //	21	MemberNumber	string
    //	22	DirectMailFlag	bool?
    //	23	EmailAccept	TempoVisorEmailAccept?
    //	24	PriceApplication	int?
    //	25	Point	int?
    //	26	PointDeposited	int?
    //	27	LastPointIssued	int?
    //	28	LastPointIssuedDate	DateTime?
    //	29	LastPointUsed	int?
    //	30	LastPointUsedDate	DateTime?
    //	31	Fillers	string
    //	32	Operation	TempoVisorOperation?
    //	33	CutoutDate	DateTime?
    //	34	ExpirationDate	DateTime?
    //	35	LastVisitedDate	DateTime?
    // ECCUBE DATA
    //  36  CompanyName string
    //  37  Fax string
    //  38  Occupation string
    //  39  FirstPurchased datetime
    //  40  LastPurchased datetime
    //  41  TimesPurchased int
    //  42  ProductWarranty string
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
        public DateTime? DateRegistered { get; set; }
        public DateTime? DateUpdated { get; set; }
        public TempoVisorData TempoVisorData { get; set; } 
        public EccubeData EccubeData { get; set; }
        public string CellPhone { get; set; } 
        public string Zip { get; set; }
        public string Note { get; set; }
        public string Address { get; set; }

        public Customer()
        {
            TempoVisorData = new TempoVisorData();
            EccubeData = new EccubeData();
        }
    }
}
