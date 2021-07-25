using _19DTHA_A_DO_AN.Models;
using _19DTHA_A_DO_AN.Models.GroceryModel;
using Microsoft.AspNet.Identity;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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

        public ActionResult Product(/*string searchString, */int? id, int page = 1, int pagesize = 4)
        {
            var products = _dbContext.Products
                .Include(n => n.ProductType)
                .Where(p => p.ProductType.id == id)
                .ToList().ToPagedList(page, pagesize);

            /* if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
             {
                 products = products
                     .Where(s => s.Name.ToLower().Contains(searchString.ToLower()))
                     .ToList().ToPagedList(page, pagesize); //lọc theo chuỗi tìm kiếm
             }*/
            return View("Products", products);
        }

        [HttpGet]
        public ActionResult Single(int ? id)
        {
            var details = _dbContext.Products
                .Where(p => p.Id == id)
                .ToList();
            return View("Single", details);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Single()
        {
            return View();
        }

        public ActionResult Payment()
        {
            return View();
        }

        // GET:
        [Authorize]
        public ActionResult ShopCart()
        {
            string UserId = User.Identity.GetUserId();
            var shopCart = _dbContext.ShopCarts
                .Where(p => p.UserId == UserId)
                .ToList();

            if (shopCart == null)
            {
                return HttpNotFound();
            }
            return View(shopCart);
        }

        // POST:
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult ShopCart([Bind(Include = "UserId,ProductId,Image,ProductName,Quatity,Price")]ShopCart shopCart)
        {
            shopCart.Total = shopCart.Price * shopCart.Quatity;
   
            ShopCart shopCart1 = _dbContext.ShopCarts.Find(shopCart.UserId, shopCart.ProductId);

            if (shopCart1 != null)
            {
                shopCart1.Quatity = shopCart.Quatity;
                shopCart1.Total = shopCart1.Price * shopCart1.Quatity;
                if (ModelState.IsValid)
                {
                    _dbContext.Entry(shopCart1).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                    return RedirectToAction("ShopCart");
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    _dbContext.ShopCarts.Add(shopCart);
                    _dbContext.SaveChanges();
                    return RedirectToAction("ShopCart");
                }
            }
            return View();
        }
    }
}