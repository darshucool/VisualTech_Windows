using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualTech.Domain
{
    public class ProductCategoryCombo
    {
        public int UId { get; set; }
        public int? MainCategoryUId { get; set; }
        public string MainCategory { get; set; }
        public string SubCategory { get; set; }
        public string DisplayName { get; set; }
        public string CategoryType { get; set; }
    }
}
