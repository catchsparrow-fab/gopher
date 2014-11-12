using System;
using Gopher.Tools;

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
    // 16	PointBalance	int?
    // TEMPO-VISOR DATA
    //	17	CompanyCode	string
    //	18	Area	int?
    //	19	Black	bool?
    //	20	MemberRank	int?
    //	21	Status	int?
    //	22	MemberNumber	string
    //	23	DirectMailFlag	bool?
    //	24	EmailAccept	TempoVisorEmailAccept?
    //	25	PriceApplication	int?
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
    //  43  Deleted bool
    //  44  SubscriptionType int
    //  45  EmailTarget int
    // MISC
    //  46   ImportedFrom int
    public class Customer : IPersistent
    {
        public InputFileType ImportedFrom { get; set; }
        public string Id { get; set; }
        public int ShopId { get; set; }
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
        public int? PointBalance { get; set; }

        // Calculated properties
        public string ShopName { get; set; }

        public Customer()
        {
            TempoVisorData = new TempoVisorData();
            EccubeData = new EccubeData();
        }

        public void Init(IDataReader reader)
        {
            ImportedFrom = reader.GetEnum<InputFileType>("ImportedFrom");
            Id = reader.GetString("CustomerId");
            ShopId = reader.GetInt32("ShopId");
            ShopName = reader.GetString("ShopName");
            Prefecture = reader.GetString("Prefecture");
            NameKanji = reader.GetString("NameKanji");
            NameKana = reader.GetString("NameKana");
            Sex = reader.GetNullableEnum<Sex>("Sex");
            DateOfBirth = reader.GetNullableDateTime("DateOfBirth");
            Email = reader.GetString("Email");
            EmailMobile = reader.GetString("EmailMobile");
            Phone = reader.GetString("Phone");
            DateRegistered = reader.GetNullableDateTime("DateRegistered");
            DateUpdated = reader.GetNullableDateTime("DateUpdated");
            Zip = reader.GetString("Zip");
            CellPhone = reader.GetString("CellPhone");
            Note = reader.GetString("Note");
            Address = reader.GetString("Address");
            PointBalance = reader.GetNullableInt32("PointBalance");

            TempoVisorData.Init(reader);
            EccubeData.Init(reader);
        }
    }
}
