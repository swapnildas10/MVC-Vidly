using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class ShoppingCartsController : Controller
    {
        private ApplicationDbContext _context;
        public ShoppingCartsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: ShoppingCarts
        public ActionResult Index()
        {
            var uid = HttpContext.User.Identity.GetUserId();
            var list = _context.ShoppingCarts.Include(s => s.Movie)
                .Where(u => u.User == uid);
            var results = list.ToList();
            
            List<UserShoppingCartViewModel> rentals = new List<UserShoppingCartViewModel>();
            foreach (ShoppingCart shoppingCart in results)
            {
                rentals.Add(new UserShoppingCartViewModel
                {
                    Movie = shoppingCart.Movie,
                     
                });
            }
            return View("Index",rentals);
        }

        //public ActionResult AddToCart(int id)
        //{
        //    var uid = HttpContext.User.Identity.GetUserId();
        //    var movie = _context.Movies.Single(m => m.Id == id);

        //    ShoppingCart cart = new ShoppingCart
        //    {
        //        Movie = movie,
        //        User = uid

        //    };

        //    _context.ShoppingCarts.Add(cart);
        //    _context.SaveChanges();
        //    return new PartialViewResult();
        //}

        public ActionResult CheckOut()
        {
            var uid = HttpContext.User.Identity.GetUserId();
            var list = _context.ShoppingCarts.Include(s => s.Movie)
                .Where(u => u.User == uid);
            var results = list.ToList();
           
            foreach (ShoppingCart item in results)
            {
                item.Movie.NumberAvailable--;
               
                _context.OnlineRentals.Add(new OnlineRentals
                {
                    Movie = item.Movie,
                    DateRented = DateTime.Now,
                    User = uid
                });
                _context.ShoppingCarts.Remove(item);
            }
            _context.SaveChanges();
            return PartialView("CheckOut");
        }
    }
}