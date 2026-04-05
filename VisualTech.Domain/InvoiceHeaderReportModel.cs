using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualTech.Domain
{
    public class InvoiceHeaderReportModel
    {
        public int UId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceNo { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public decimal GrandTotal { get; set; }
        public string CustomerName { get; set; }
        public decimal PaidAmount { get; set; }
        public int InvoiceTypeId { get; set; }
        public decimal DueAmount { get; set; }

        public bool ShowDueAmount
        {
            get { return CustomerId.HasValue && CustomerId.Value > 0; }
        }
    }
}
