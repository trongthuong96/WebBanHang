using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _19DTHA_A_DO_AN.Models.GroceryModel
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tên Sản Phẩm")]
        public string Name { get; set; }
        [Display(Name = "Giá Sản Phẩm")]
        public double Price { get; set; }
        [Display(Name = "Giá Khuyến Mãi")]
        public double DiscountAmount { get; set; }
        [Display(Name = "Chi tiết sẩn phẩm")]
        public string Description { get; set; }
        [Display(Name = "Ảnh")]
        public string Image { get; set; }

        [ForeignKey("ProductType")]
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }

        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}