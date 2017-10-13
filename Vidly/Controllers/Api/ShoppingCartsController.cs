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
            if (movies.NumberAvailable ==0)
                return Content(HttpStatusCode.Forbidden,"Out of Stock");
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
         [System.Web.Http.Route("api/savedmovies")]
        public IHttpActionResult GetSavedItems()
        {
            var uid = HttpContext.Current.User.Identity.GetUserId();
            var saveditems = _context.SavedMovies.Include(m => m.Movie).Where(s => s.User == uid).ToList();
            if(saveditems.Count<=0)
            return NotFound();
            List<SavedMoviesViewModel> savedMovies = new List<SavedMoviesViewModel>();
             foreach (SavedMovie savedMovie in saveditems)
            {
               savedMovies.Add(new SavedMoviesViewModel
               {
                   MovieId = savedMovie.Movie.Id,
                   Name = savedMovie.Movie.Name,
                   Stock = savedMovie.Movie.NumberAvailable
               });
            }
             
            return Ok(savedMovies);
        }
        [System.Web.Http.HttpPut]
        public IHttpActionResult SaveMovie(int id)
        {
            var movie = _context.Movies.Single(m => m.Id == id);
            var uid = HttpContext.Current.User.Identity.GetUserId();
            var savedMovies = _context.SavedMovies.Include(m => m.Movie).Where(m => m.User == uid);
            if (savedMovies.Where(m => m.Movie.Id == id).ToList().Any())
            return Content(HttpStatusCode.Forbidden, "Duplicate Entry");

            _context.SavedMovies.Add(new SavedMovie
            {
                Movie = movie,
                User = uid
            });
            _context.SaveChanges();
            return Ok("Saved for Later");
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
    }
}
