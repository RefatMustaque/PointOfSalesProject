﻿using POS.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PointOfSalesSystem.Models.ViewModels
{
    public class ItemCategoryCreateVM
    {
        
        public string Name { get; set; }
        [Display(Name= "Code")]
        public string ItemCategoryCode { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string RadioButton { get; set; }
        
        //Item Category ParentId REFER
        public int? ParentId { get; set; }
        public List<ItemCategory> Parent { get; set; }

        
       
    }
}