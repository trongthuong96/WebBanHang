using _19DTHA_A_DO_AN.Models;
using _19DTHA_A_DO_AN.Models.GroceryModel;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _19DTHA_A_DO_AN.Controllers
{
    public class GroceryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public GroceryController()
        {
            _dbContext = new ApplicationDbContext();
        }

        // GET: Store

        public ActionResult Menu()
        {
            var type = _dbContext.ProductTypes
                .ToList();
            return View("Menu",type);
        }

        public ActionResult Product(int ? id, int page = 1, int pagesize = 4)
        {
            var products = _dbContext.Products
                .Include(n => n.ProductType)
                .Where(p => p.ProductType.id == id)
                .ToList().ToPagedList(page, pagesize);
            return View("Products", products);
        }

        public ActionResult Single(int ? id)
        {
            var details = _dbContext.Products
                .Where(p => p.Id == id)
                .ToList();
            return View("Single", details);
        }
    }
}