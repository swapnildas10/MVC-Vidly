using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Glimpse.Core.Extensions;
using Microsoft.AspNet.Identity;
using Vidly.Models;
using WebGrease.Css.Extensions;

namespace Vidly.Controllers.Api
{
    public class ShoppingCartsController : ApiController
    {
        private ApplicationDbContext _context;
        public ShoppingCartsController()
        {
           _context=new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult AddMovieToShoppingCart(int id )
        {
            var uid = HttpContext.Current.User.Identity.GetUserId();
          
            var cartitem = _context.ShoppingCarts.Where(s => s.User == uid);
            if (cartitem.Any(c => c.Movie.Id == id))
                return BadRequest("Already in Cart");
            var movie = _context.Movies.Single(m => m.Id == id);
            ShoppingCart cart = new ShoppingCart
            {
                Movie = movie,
                User = uid

            };
           
            _context.ShoppingCarts.Add(cart);
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet]
        
        public IHttpActionResult GetItemsforShoppingCart()
        {
            var uid = HttpContext.Current.User.Identity.GetUserId();
            //how to aggregate 
            var items = _context.ShoppingCarts.Include(m=>m.Movie).Where(s => s.User == uid).ToList();
            if (items.Count == 0)
                return Ok(0.00);
            var total = 0.00;
            foreach (ShoppingCart item in items)
            {
                total =+ (Double)item.Movie.Cost;
            }
           
            return Ok(total);
        }
        
        [HttpDelete]
        public IHttpActionResult DeleteItemfromShoppingCart(int id)
        {
            var uid = HttpContext.Current.User.Identity.GetUserId();
            var item = _context.ShoppingCarts.Single(s => s.User == uid && s.Movie.Id == id);
           
            _context.ShoppingCarts.Remove(item);
            _context.SaveChanges();
            return Ok();
        }
    }
}
