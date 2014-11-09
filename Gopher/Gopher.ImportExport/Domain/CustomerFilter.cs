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
        public int? Count { get; set; }
        public int? Start { get; set; }

        public CustomerFilter()
        {
            DateOfBirth = new Range<DateTime>();
            TimesPurchased = new Range<int>();
            Count = 20;
        }
    }
}
