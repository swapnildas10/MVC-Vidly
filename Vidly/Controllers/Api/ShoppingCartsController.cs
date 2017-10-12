using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Glimpse.Core.Extensions;
using Microsoft.AspNet.Identity;
using Vidly.Models;

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
            var items = _context.ShoppingCarts.Where(s => s.User == uid);

            return null;
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
