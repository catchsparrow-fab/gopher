using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gopher.Tools;

namespace Gopher.ImportExport.Domain
{
    public enum TempoVisorEmailAccept
    {
        DoNotSend = 0,
        SendToEmail1 = 1,
        SendToEmail2 = 2,
        SendBoth = 3
    }

    public enum TempoVisorOperation
    {
        New = 1,
        Modified = 2,
        Delete = 3
    }

    public class TempoVisorData : IPersistent
    {
        public string CompanyCode { get; set; }
        public int? Area { get; set; }
        public bool? Black { get; set; }
        public int? MemberRank { get; set; }
        public int? Status { get; set; }
        public string MemberNumber { get; set; }
        public bool? DirectMailFlag { get; set; }
        public TempoVisorEmailAccept? EmailAccept { get; set; }
        public int? PriceApplication { get; set; }
        public int? PointDeposited { get; set; }
        public int? LastPointIssued { get; set; }
        public DateTime? LastPointIssuedDate { get; set; }
        public int? LastPointUsed { get; set; }
        public DateTime? LastPointUsedDate { get; set; }
        public string Fillers { get; set; } // 9 elements
        public TempoVisorOperation? Operation { get; set; }
        public DateTime? CutoutDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? LastVisitedDate { get; set; }

        public void Init(IDataReader reader)
        {
            CompanyCode = reader.GetString("TV_CompanyCode");
            Area = reader.GetNullableInt32("TV_Area");
            Black = reader.GetNullableBoolean("TV_Black");
            MemberRank = reader.GetNullableInt32("TV_MemberRank");
            Status = reader.GetNullableInt32("TV_Status");
            MemberNumber = reader.GetString("TV_MemberNumber");
            DirectMailFlag = reader.GetNullableBoolean("TV_DirectMailFlag");
            EmailAccept = reader.GetNullableEnum<TempoVisorEmailAccept>("TV_EmailAccept");
            PriceApplication = reader.GetNullableInt32("TV_PriceApplication");
            PointDeposited = reader.GetNullableInt32("TV_PointDeposited");
            LastPointIssued = reader.GetNullableInt32("TV_LastPointIssued");
            LastPointIssuedDate = reader.GetNullableDateTime("TV_LastPointIssuedDate");
            LastPointUsed = reader.GetNullableInt32("TV_LastPointUsed");
            LastPointUsedDate = reader.GetNullableDateTime("TV_LastPointUsedDate");
            Fillers = reader.GetString("TV_Fillers");
            Operation = reader.GetNullableEnum<TempoVisorOperation>("TV_Operation");
            CutoutDate = reader.GetNullableDateTime("TV_CutoutDate");
            ExpirationDate = reader.GetNullableDateTime("TV_ExpirationDate");
            LastVisitedDate = reader.GetNullableDateTime("TV_LastVisitedDate");
        }
    }
}
