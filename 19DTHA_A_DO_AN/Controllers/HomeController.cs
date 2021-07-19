using _19DTHA_A_DO_AN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace _19DTHA_A_DO_AN.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public ActionResult Index(string searchString, int page =1 ,int pagesize = 16 )
        {
            var products = _dbContext.Products
                .ToList().ToPagedList(page, pagesize);

            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                products = products
                    .Where(s => s.Name.ToLower().Contains(searchString.ToLower()))
                    .ToList().ToPagedList(page, pagesize); //lọc theo chuỗi tìm kiếm
            }

            return View("Index", products);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}