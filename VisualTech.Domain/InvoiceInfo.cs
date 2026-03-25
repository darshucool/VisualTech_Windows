using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualTech.Domain
{
    public class InvoiceInfo
    {
        public int UId { get; set; }
        public int CustomerId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int Status { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int InvoiceTypeId { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceLine1 { get; set; }
        public string InvoiceLine2 { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public decimal GrandTotal { get; set; }
        public string CustomerName { get; set; }
        public decimal PaidAmount { get; set; }
    }
}
