using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gopher.ImportExport.Domain
{
    public class EccubeData
    {
        public string CompanyName { get; set; }
        public string Fax { get; set; }
        public string Occupation { get; set; }
        public DateTime? DateFirstPurchased { get; set; }
        public DateTime? DateLastPurchased { get; set; }
        public int? TimesPurchased { get; set; }
        public string ProductWarranty { get; set; }
    }
}
