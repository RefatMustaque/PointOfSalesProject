using POS.BLL.BaseManager;
using POS.Models.EntityModel;
using POS.Repository.Base;
using POS.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BLL.ManagerRepositories
{
    public class StockManager : Manager<Stock>
    {
        public StockManager() : base(new StockRepository())
        {
        }

        public void UpdateStockWithPurchaseReceiving(List<PurchaseReceivingDetails> PurchaseReceivingDetailses, int PurchaseReceivingBranchId)
        {
            foreach (PurchaseReceivingDetails purchaseReceivingDetails in PurchaseReceivingDetailses)
            {
                var ExistingStock = this.GetFirstOrDefault(c => c.ItemId == purchaseReceivingDetails.ItemId && c.BranchId == PurchaseReceivingBranchId);
                if (ExistingStock == null)
                {
                    var Stock = new Stock();
                    Stock.AvgPrice = purchaseReceivingDetails.PurchasePrice;
                    Stock.StockQuantity = purchaseReceivingDetails.Quantity;
                    Stock.ItemId = purchaseReceivingDetails.ItemId;
                    Stock.BranchId = PurchaseReceivingBranchId;
                    Stock.CategoryFullPath = "Does not exist";
                    this.Save(Stock);
                }

                else
                {
                    ExistingStock.AvgPrice = (ExistingStock.StockQuantity * ExistingStock.AvgPrice + purchaseReceivingDetails.Quantity * purchaseReceivingDetails.PurchasePrice) / (ExistingStock.StockQuantity + purchaseReceivingDetails.Quantity);
                    ExistingStock.StockQuantity = ExistingStock.StockQuantity + purchaseReceivingDetails.Quantity;
                    ExistingStock.CategoryFullPath = "Exist";
                    this.Update(ExistingStock);
                }


            }
        }
    }
}
