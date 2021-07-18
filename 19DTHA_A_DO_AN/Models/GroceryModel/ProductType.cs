using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _19DTHA_A_DO_AN.Models.GroceryModel
{
    public class ProductType
    {
        [Key]
        public int id { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}