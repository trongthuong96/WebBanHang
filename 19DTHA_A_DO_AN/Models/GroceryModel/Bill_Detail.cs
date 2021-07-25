using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _19DTHA_A_DO_AN.Models.GroceryModel
{
    public class Bill_Detail
    {
        [Key]
        public int Id { get; set; }
        public int Quantily { get; set; }
        public double Price { get; set; }
        public DateTime Create_at { get; set; }
        public DateTime Update_at { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey("Bill")]
        public int BillId { get; set; }
        public Bill Bill { get; set; }
    }
}