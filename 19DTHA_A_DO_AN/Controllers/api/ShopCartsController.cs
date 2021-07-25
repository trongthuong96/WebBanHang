using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using _19DTHA_A_DO_AN.Models;
using _19DTHA_A_DO_AN.Models.GroceryModel;
using Microsoft.AspNet.Identity;

namespace _19DTHA_A_DO_AN.Controllers.api
{
    public class ShopCartsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ShopCarts
       /* public IQueryable<ShopCart> GetShopCarts()
        {
            return db.ShopCarts;
        }*/

        // GET: api/ShopCarts/5
      /*  [ResponseType(typeof(ShopCart))]
        public IHttpActionResult GetShopCart(string id)
        {
            ShopCart shopCart = db.ShopCarts.Find(id);
            if (shopCart == null)
            {
                return NotFound();
            }

            return Ok(shopCart);
        }*/

        // PUT: api/ShopCarts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutShopCart(string id, ShopCart shopCart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shopCart.UserId)
            {
                return BadRequest();
            }

            db.Entry(shopCart).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShopCartExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ShopCarts
        /*[ResponseType(typeof(ShopCart))]
        public IHttpActionResult PostShopCart(ShopCart shopCart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ShopCarts.Add(shopCart);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ShopCartExists(shopCart.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = shopCart.UserId }, shopCart);
        }*/

        // DELETE: api/ShopCarts/5
        [ResponseType(typeof(ShopCart))]
        public IHttpActionResult DeleteShopCart(int id)
        {
            string userId = User.Identity.GetUserId();

            ShopCart shopCart = db.ShopCarts.Find(userId, id);
            if (shopCart == null)
            {
                return NotFound();
            }

            db.ShopCarts.Remove(shopCart);
            db.SaveChanges();

            return Ok(shopCart);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShopCartExists(string id)
        {
            return db.ShopCarts.Count(e => e.UserId == id) > 0;
        }
    }
}