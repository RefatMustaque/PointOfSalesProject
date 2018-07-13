using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PointOfSalesSystem.Models.ViewModels
{
	public class StockReadVM
	{
		public ICollection<StockCreateVM> StockCreateVMs { get; set; }

		public ICollection<BranchesCreateVM> BranchesCreateVMs { get; set; }
	}
}