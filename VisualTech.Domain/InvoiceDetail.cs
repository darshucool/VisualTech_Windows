using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualTech.Domain
{
    public class InvoiceDetail
    {
        public int UId { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public string ItemName { get; set; }
        public string Warranty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string BarcodeDetail { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public decimal Quantity { get; set; }
        public decimal Qty { get; set; }
    }
}
