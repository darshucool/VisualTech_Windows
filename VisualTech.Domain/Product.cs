using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualTech.Domain
{
    public  class Product : Entity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal MRPPrice { get; set; }
        public int SubCatUId { get; set; }
        public int BrandUId { get; set; }
        public string Description { get; set; }
    }
}
