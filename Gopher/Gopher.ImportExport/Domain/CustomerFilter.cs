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
        //public Range<decimal> AmountPurchased { get; set; }
        public Range<int> TimesPurchased { get; set; }
        //public Range<DateTime> DateRegistered { get; set; }
        public int? Page { get; set; }

        public CustomerFilter()
        {
            DateOfBirth = new Range<DateTime>();
            TimesPurchased = new Range<int>();
            Page = 1;
            Sex = new Sex[0];
        }
    }
}
