using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualTech.Domain
{
    public class ProductCategoryCombo
    {
        public int UId { get; set; }                 // SubCategory UId
        public int MainCategoryUId { get; set; }     // Parent Category UId
        public string MainCategory { get; set; }
        public string SubCategory { get; set; }

        public string DisplayName
        {
            get { return MainCategory + " - " + SubCategory; }
        }
    }
}
