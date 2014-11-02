using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public class TempoVisorData
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
    }
}
