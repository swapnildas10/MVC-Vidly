using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Glimpse.Core.Extensions;
using Microsoft.AspNet.Identity;
using Vidly.Models;
using Vidly.ViewModels;
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
        [System.Web.Http.HttpPost]
        public IHttpActionResult AddMovieToShoppingCart(int id )
        {
            var uid = HttpContext.Current.User.Identity.GetUserId();
            var movies = _context.Movies.Single(m => m.Id == id);
            var cartitem = _context.ShoppingCarts.Include(s=>s.Movie).Where(s => s.User == uid);
            if (cartitem.Any(c => c.Movie.Id == id))
                return Content(HttpStatusCode.Forbidden, "Already present in your cart");
            if (movies.NumberAvailable <=0)
                return Content(HttpStatusCode.Forbidden,"Out of Stock");
            var isrented = _context.OnlineRentals.Include(s=>s.Movie).Where(s=>s.User == uid);
            if (isrented.Any(s => s.Movie.Id == id))
            {
                return Content(HttpStatusCode.Forbidden, "Already Rented");
            }

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
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/shoppingcarts")]
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


        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/mycart")]
        public IHttpActionResult GetItems()
        {
            var uid = HttpContext.Current.User.Identity.GetUserId();
            //how to aggregate 
            var items = _context.ShoppingCarts.Include(m => m.Movie).Where(s => s.User == uid).ToList();
            if (items.Count == 0)
                return NotFound();
             List<UserShoppingCartViewModel> userShoppingCartView = new List<UserShoppingCartViewModel>();
            foreach (ShoppingCart cart in items)
            {
                userShoppingCartView.Add(new UserShoppingCartViewModel
                {
                    Movie = cart.Movie
                });
            }
            return Ok(userShoppingCartView);
        }

        [System.Web.Http.HttpGet]
         
        public IHttpActionResult GetItemforShoppingCart(int id)
        {
            var uid = HttpContext.Current.User.Identity.GetUserId();
            //how to aggregate 
            var item = _context.ShoppingCarts.Include(m => m.Movie).Single(s => s.User == uid && s.Movie.Id==id);
            
            UserShoppingCartViewModel userShoppingCartViewModel = new UserShoppingCartViewModel
            {
                Movie = item.Movie
            };
            return Ok(userShoppingCartViewModel);
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteItemfromShoppingCart(int id)
        {

            var uid = HttpContext.Current.User.Identity.GetUserId();
            var item = _context.ShoppingCarts.Single(s => s.User == uid && s.Movie.Id == id);
           
            _context.ShoppingCarts.Remove(item);
            _context.SaveChanges();
            return Ok();
        }
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/buyitems")]
        public IHttpActionResult MoveItemfromCartToMyRental()
        {
            var uid = HttpContext.Current.User.Identity.GetUserId();
            var items = _context.ShoppingCarts.Include(m=>m.Movie).Where(s => s.User == uid).ToList();
            if(items.Count == 0)
            {
                return Content(HttpStatusCode.NotFound, "Your Cart is empty");
            }

            OnlineRentals onlineRental = null;
            ShoppingCart cartItem = null;
            foreach (var item in items) {
                onlineRental = new OnlineRentals
                {

                    Movie = item.Movie,
                    DateRented = DateTime.Now,
                    User = uid

                };
                cartItem = new ShoppingCart
                {
                    Movie = item.Movie,
                    User = uid
                };
                _context.OnlineRentals.Add(onlineRental);
                // empty shopping cart here
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
