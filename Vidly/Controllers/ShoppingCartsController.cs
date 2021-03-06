﻿using System;
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
        private readonly ApplicationDbContext _context;
        public ShoppingCartsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: ShoppingCarts
        public ActionResult Index()
        {
            var uid = HttpContext.User.Identity.GetUserId();
            bool cartChanged = false;
            var list = _context.ShoppingCarts.Include(u => u.Movie)
                .Where(u => u.User == uid);
            var results = list.ToList();
            var savedMovies = _context.SavedMovies.Include(u=>u.Movie).Where(u => u.User == uid);
            if (list.Where(m => m.Movie.NumberAvailable <= 0).ToList().Any())
            {
                cartChanged = true;
            }
                List<UserShoppingCartViewModel> rentals = new List<UserShoppingCartViewModel>();
            
            foreach (ShoppingCart shoppingCart in results)
            {
                if (shoppingCart.Movie.NumberAvailable > 0)
                {
                    rentals.Add(new UserShoppingCartViewModel
                    {
                        Movie = shoppingCart.Movie

                    });
                }
                else
                {
                     
                    if (!savedMovies.Where(m=>m.Movie.Id==shoppingCart.Movie.Id).ToList().Any())
                    {
                        _context.SavedMovies.Add(new SavedMovie
                        {
                            Movie = shoppingCart.Movie,
                            User = uid
                        });
                        _context.ShoppingCarts.Remove(shoppingCart);
                    }
                    _context.ShoppingCarts.Remove(shoppingCart);


                }
               
            }
            ViewBag.cartChanged = cartChanged;
            _context.SaveChanges();
            return View("Index",rentals);
        }

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