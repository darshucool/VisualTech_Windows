using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualTech.Domain
{
    public class CustomerPayment
    {
        public int UId { get; set; }
        public int? CustomerId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? Date { get; set; }
    }
}
