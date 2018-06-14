using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models.EntityModel
{
   public class Stock
    {
        public int Id { get; set; }
        public int StockQuantity { get; set; }

        public double AvgPrice { get; set; }

        public string CategoryFullPath { get; set; }



        public int? BranchId { get; set; }
        public virtual Branch Branch { get; set; }

        //Item Reference
        public int? ItemId { get; set; }
        public virtual Item Item { get; set; }
    }
}
