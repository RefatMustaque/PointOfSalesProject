using AutoMapper;
using PointOfSalesSystem.Models.ViewModels;
using POS.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PointOfSalesSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ItemCategoryCreateVM, ItemCategory>();
                
                cfg.CreateMap<OrganizationsCreateVM, Organizations>();
                
                cfg.CreateMap<BranchesCreateVM, Branch>();
                
                cfg.CreateMap<ItemCreateVM, Item>();
                
                cfg.CreateMap<ExpenseCategoryCreateVM, ExpenseCategory>();
                
                cfg.CreateMap<ExpenseItemCreateVM, ExpenseItem>();
                
                cfg.CreateMap<PartyCreateVM, Party>();
                
                cfg.CreateMap<PurchaseReceivingCreateVM, PurchaseReceiving>();
                
                cfg.CreateMap<EmployeeInfoCreateVM, EmployeeInfo>();
                
                cfg.CreateMap<SalesCreateVM, Sales>();
                
                cfg.CreateMap<ExpenseCreateVM, Expense>();
                
                cfg.CreateMap<StockCreateVM, Stock>();
                cfg.CreateMap<Stock, StockCreateVM>();


            }
             );
        }
    }
}
