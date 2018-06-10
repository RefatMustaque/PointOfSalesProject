using AutoMapper;
using PointOfSalesSystem.Models.ViewModels;
using POS.BLL.ManagerRepositories;
using POS.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PointOfSalesSystem.Controllers
{
    public class PurchaseReceivingController : Controller
    {
        PurchaseReceivingManager _purchaseReceivingManager = new PurchaseReceivingManager();
        BranchManager _branchManager = new BranchManager();
        EmployeeInfoManager _employeeInfoManager = new EmployeeInfoManager();
        ItemManager _itemManager = new ItemManager(); //item Manager for dropdown
        PurchaseReceivingDetailsManager _PurchaseReceivingDetailsManager = new PurchaseReceivingDetailsManager();
        StockManager _stockManager = new StockManager();
        PartyManager _partyManager = new PartyManager();
        // GET: PurchaseReceiving
        public ActionResult Index()
        {
            return View();
        }

        // GET: PurchaseReceiving/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PurchaseReceiving/Create
        public ActionResult Create()
        {
            var model = new PurchaseReceivingCreateVM();
            var item = _itemManager.GetAll();
            model.Items = item;
            var branch = _branchManager.GetAll();
            model.Branches = branch;
            var employeeInfo = _employeeInfoManager.GetAll();
            model.EmployeeInfoes = employeeInfo;
            model.Parties = _partyManager.Get(c=>c.PartyType=="Supplier");

            ViewBag.EmployeeInfoId = new List<SelectListItem>()
            {
                new SelectListItem(){ Value="",Text="Select" }
            };

            return View(model);
        }

        // POST: PurchaseReceiving/Create
        [HttpPost]
        public ActionResult Create(PurchaseReceivingCreateVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _stockManager.UpdateStockWithPurchaseReceiving(model.PurchaseReceivingDetailses, model.BranchId);
                    var purchaseReceiving = Mapper.Map<PurchaseReceiving>(model);
                    bool isSaved = _purchaseReceivingManager.Save(purchaseReceiving);
                    if (isSaved)
                    {
                        return RedirectToAction("Create");
                    }
                        
                }

            }
            catch (Exception exception)
            {
                ModelState.AddModelError("", exception.Message);


                var itemList = _itemManager.GetAll();
                model.Items = itemList;
                var branchList = _branchManager.GetAll();
                model.Branches = branchList;
                var employeeInfoList = _employeeInfoManager.GetAll();
                model.EmployeeInfoes = employeeInfoList;
                model.Parties = _partyManager.Get(c => c.PartyType == "Supplier");
                return View(model);
            }

            var item = _itemManager.GetAll();
            model.Items = item;
            var branch = _branchManager.GetAll();
            model.Branches = branch;
            var employeeInfo = _employeeInfoManager.GetAll();
            model.EmployeeInfoes = employeeInfo;
            model.Parties = _partyManager.Get(c => c.PartyType == "Supplier");
            return View(model);
        }

        // GET: PurchaseReceiving/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PurchaseReceiving/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PurchaseReceiving/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PurchaseReceiving/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void UpdateStockWithNewPurchaseReceiving(List<PurchaseReceivingDetails> PurchaseReceivingDetailses, int PurchaseReceivingBranchId)
        {
            foreach (PurchaseReceivingDetails purchaseReceivingDetails in PurchaseReceivingDetailses)
            {
                var ExistingStock = _stockManager.GetFirstOrDefault(c => c.ItemId == purchaseReceivingDetails.ItemId && c.BranchId == PurchaseReceivingBranchId);
                if (ExistingStock == null)
                {
                    var Stock = new StockCreateVM();
                    Stock.AvgPrice = (Stock.StockQuantity * Stock.AvgPrice + purchaseReceivingDetails.Quantity * purchaseReceivingDetails.PurchasePrice) / (Stock.StockQuantity + purchaseReceivingDetails.Quantity);
                    Stock.StockQuantity = Stock.StockQuantity + purchaseReceivingDetails.Quantity;
                    Stock.ItemId = purchaseReceivingDetails.ItemId;
                    Stock.BranchId = PurchaseReceivingBranchId;
                    Stock.CategoryFullPath = "Does not exist";
                    var MappedStock = Mapper.Map<Stock>(Stock);
                    bool StockIsSaved = _stockManager.Save(MappedStock);
                }

                else
                {
                    ExistingStock.AvgPrice = (ExistingStock.StockQuantity * ExistingStock.AvgPrice + purchaseReceivingDetails.Quantity * purchaseReceivingDetails.PurchasePrice) / (ExistingStock.StockQuantity + purchaseReceivingDetails.Quantity);
                    ExistingStock.StockQuantity = ExistingStock.StockQuantity + purchaseReceivingDetails.Quantity;
                    ExistingStock.CategoryFullPath = "Exist";
                    var MappedStock = Mapper.Map<Stock>(ExistingStock);
                    bool StockIsSaved = _stockManager.Update(MappedStock);
                }
                

            }
        }
    }
}
