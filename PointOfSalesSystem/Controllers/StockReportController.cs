using AutoMapper;
using PointOfSalesSystem.Models.ViewModels;
using POS.BLL.ManagerRepositories;
using System.Web.Mvc;

namespace PointOfSalesSystem.Controllers
{
    public class StockReportController : Controller
    {

        StockManager _stockManager = new StockManager();

        // GET: StockReport
        public ActionResult Index()
        {
			//var stock = _stockManager.GetAll();
			//StockReadVM model = new StockReadVM();
			//model.StockCreateVMs = Mapper.Map<IList<StockCreateVM>>(stock);
            var model = _stockManager.GetAll();

            return View(model);
        }

        // GET: StockReport/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StockReport/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StockReport/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StockReport/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StockReport/Edit/5
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

        // GET: StockReport/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StockReport/Delete/5
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
    }
}
