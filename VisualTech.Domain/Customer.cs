using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualTech.Domain
{
    public  class Customer : Entity
    {
        public string CutomerName { get; set; }
        public string CompanyName { get; set; }
        public string HomeAddress { get; set; }
        public string OfficeAddress { get; set; }
        public string MobileNo { get; set; }
        public string Landline { get; set; }
        public string Email { get; set; }
        public decimal CurrentBalance { get; set; }
    }
}
