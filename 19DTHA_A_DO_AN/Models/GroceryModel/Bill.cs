using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _19DTHA_A_DO_AN.Models.GroceryModel
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateOrder { get; set; }
        public string Note { get; set; }
        public double Total { get; set; }
        public string Status { get; set; }
        public DateTime Create_at { get; set; }
        public DateTime Update_at { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<Bill_Detail> Bill_Details { get; set; }
    }
}