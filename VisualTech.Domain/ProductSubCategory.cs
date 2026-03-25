using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualTech.Domain
{
    public  class ProductSubCategory : Entity
    {
        public int MainCategoryUId { get; set; }
        public string Category { get; set; }
    }
}
