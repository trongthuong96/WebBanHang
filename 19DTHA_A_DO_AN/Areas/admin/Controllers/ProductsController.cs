using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _19DTHA_A_DO_AN.Models;
using _19DTHA_A_DO_AN.Models.GroceryModel;

namespace _19DTHA_A_DO_AN.Areas.admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: admin/Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Manufacturer).Include(p => p.ProductType);
            return View(products.ToList());
        }

        // GET: admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name");
            ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "id", "Name");
            return View();
        }

        // POST: admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,Description,Image,ProductTypeId,ManufacturerId")] Product product, HttpPostedFileBase Image)
        {

            if (Image != null && Image.ContentLength > 0)
            {
                string filename = System.IO.Path.GetFileName(Image.FileName);
                string fullPath = Request.MapPath("~/Asset/images/" + filename);
                if (System.IO.File.Exists(fullPath))
                {
                    /*ViewBag.SuccessMessage = "Item has been added!";*/
                    ViewBag.Message = "Trung ten anh, vui long doi ten";
                    ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name", product.ManufacturerId);
                    ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "id", "Name", product.ProductTypeId);
                    return View();
                }
                string urlImage = Server.MapPath("~/Asset/images/" + filename);
                Image.SaveAs(urlImage);
                product.Image = filename;
            }    

            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name", product.ManufacturerId);
            ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "id", "Name", product.ProductTypeId);
            return View(product);
        }

        // GET: admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name", product.ManufacturerId);
            ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "id", "Name", product.ProductTypeId);
            return View(product);
        }

        // POST: admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Description,Image,ProductTypeId,ManufacturerId")] Product product, HttpPostedFileBase editImage)
        {
            Product modifyProduct = db.Products.Find(product.Id);

            if (modifyProduct != null)
            {
                if(editImage != null && editImage.ContentLength > 0)
                {
                    string fullPath = Request.MapPath("~/Asset/images/" + modifyProduct.Image);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                    string filename = System.IO.Path.GetFileName(editImage.FileName);
                    string urlImage = Server.MapPath("~/Asset/images/" + filename);
                    editImage.SaveAs(urlImage);
                    modifyProduct.Image = filename;
                }    
            }

            if (ModelState.IsValid)
            {
                db.Entry(modifyProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name", product.ManufacturerId);
            ViewBag.ProductTypeId = new SelectList(db.ProductTypes, "id", "Name", product.ProductTypeId);
            return View(product);
        }

        // GET: admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            string fullPath = Request.MapPath("~/Asset/images/" + product.Image);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
