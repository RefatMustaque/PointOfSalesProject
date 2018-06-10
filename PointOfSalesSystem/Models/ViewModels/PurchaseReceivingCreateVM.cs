using POS.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PointOfSalesSystem.Models.ViewModels
{
    public class PurchaseReceivingCreateVM
    {
        public int Id { get; set; }
       
        
        [Display(Name = "Purchase No")]
        public int PurchaseNumber { get; set; }
        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }
        
        public string Remarks { get; set; }
        [Display(Name = "Purchase Total Amount")]
        public double PurchaseTotalAmount { get; set; }

        
        public List<Item> Items { get; set; }

        [Display(Name = "Branch")]
        //Branch Refered
        [Required(ErrorMessage = "Branch Information is required")]
        public int BranchId { get; set; }
        public List<Branch> Branches { get; set; }

        [Display(Name = "Supplier")]
        //Supplier Refered
        [Required(ErrorMessage = "Supplier Information is required")]
        public int? PartyId { get; set; }
        public List<Party> Parties { get; set; }


        [Display(Name = "Employee")]
        //Employee Refered
        [Required(ErrorMessage = "Employee Information is required")]
        public int? EmployeeInfoId { get; set; }
        public List<EmployeeInfo> EmployeeInfoes { get; set; }

        public List<PurchaseReceivingDetails> PurchaseReceivingDetailses { get; set; }

    }
}