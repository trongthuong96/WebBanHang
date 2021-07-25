using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _19DTHA_A_DO_AN.Models.GroceryModel
{
    public class ShopCart
    {
        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ProductId { get; set; }

        [Display(Name = "Tên Sản Phẩm")]
        public string ProductName { get; set; }
        [Display(Name = "Số lượng")]
        public int Quatity { get; set; }
        [Display(Name = "Giá")]
        public double Price { get; set; }
        [Display(Name = "Tổng tiền 1 sản phẩm")]
        public double Total { get; set; }
        [Display(Name = "Hình ảnh")]
        public string Image { get; set; }
    }
}