using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Vidly.Models;
using Vidly.ViewModels;


namespace Vidly.Controllers.Api
{
    public class OnlineRentalsController : ApiController
    {
        private ApplicationDbContext _context;
        public OnlineRentalsController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpGet]
        [Route("api/mycurrentrentals")]
        public IHttpActionResult GetCurrentRentals()
        {
            var uid = HttpContext.Current.User.Identity.GetUserId();
            var currentRentals = _context.OnlineRentals.Include(m=>m.Movie).Where(m => m.User == uid && m.DateReturned == null).ToList();
            if (currentRentals.Count == 0)
                return Content(HttpStatusCode.NoContent, "No Rentals");
            List<OnlineRentalVIewModel> onlineRentalVIewModel = new List<OnlineRentalVIewModel>();

            foreach (OnlineRentals rental in currentRentals)
            {
                onlineRentalVIewModel.Add(new OnlineRentalVIewModel
                {
                    DateRented = rental.DateRented,
                    Movie = rental.Movie,
                    DateReturned = rental.DateReturned
                });
            }       
            return Ok(onlineRentalVIewModel);
        }
        [Route("api/mycurrentrental/{id}")]
        [HttpGet]
        public IHttpActionResult GetCurrentRental(int id)
        {
            var uid = HttpContext.Current.User.Identity.GetUserId();
            var currentRental = _context.OnlineRentals.Include(m => m.Movie).Single(m => m.User == uid &&m.Movie.Id==id && m.DateReturned == null);
         
            OnlineRentalVIewModel onlineRentalVIewModel = new OnlineRentalVIewModel
            {      DateReturned = DateTime.Now,
                DateRented = currentRental.DateRented,
                Movie = currentRental.Movie
            };

             
            return Ok(onlineRentalVIewModel);
        }
        [HttpPost]
        public IHttpActionResult ReturnCurrentRental(OnlineRentalVIewModel onlineRentalVIewModel)
        {
            var uid = HttpContext.Current.User.Identity.GetUserId();
            var currentRental = _context.OnlineRentals.Include(m => m.Movie).Single(m => m.User == uid && m.Movie.Id == onlineRentalVIewModel.Movie.Id && m.DateReturned == null);

            currentRental.DateReturned = onlineRentalVIewModel.DateReturned;
            _context.SaveChanges();


            return Ok();
        }
        [HttpPost]
        public IHttpActionResult ReturnCurrentRentals(List<OnlineRentalVIewModel> onlineRentalVIewModels)
        {
            var uid = HttpContext.Current.User.Identity.GetUserId();
            var currentRental = _context.OnlineRentals.Include(m => m.Movie).Where(m => m.User == uid  && m.DateReturned == null) ;
            foreach (OnlineRentalVIewModel onlineRentalVIewModel in onlineRentalVIewModels)
            {
               if(currentRental.Any(m => m.Id == onlineRentalVIewModel.Movie.Id))
               {
                   var movie =currentRental.Single(r => r.Movie.Id == onlineRentalVIewModel.Movie.Id);
                   movie.DateReturned = onlineRentalVIewModel.DateReturned;

               }
            }
            
            _context.SaveChanges();


            return Ok();
        }

        [HttpGet]
        [Route("api/mypastrentals")]
        public IHttpActionResult GetPastRentals()
        {
            var uid = HttpContext.Current.User.Identity.GetUserId();
            var currentRentals = _context.OnlineRentals.Include(m => m.Movie).Where(m => m.User == uid && m.DateReturned != null).ToList();
            if (currentRentals.Count == 0)
                return Content(HttpStatusCode.NoContent, "No Rentals");
            List<OnlineRentalVIewModel> onlineRentalVIewModel = new List<OnlineRentalVIewModel>();

            foreach (OnlineRentals rental in currentRentals)
            {
                onlineRentalVIewModel.Add(new OnlineRentalVIewModel
                {
                    DateRented = rental.DateRented,
                    Movie = rental.Movie,
                    DateReturned = rental.DateReturned
                });
            }
            return Ok(onlineRentalVIewModel);
        }
        [Route("api/returnitem/{id}")]
        [HttpDelete]
        
        public IHttpActionResult DeleteRentalItem(int id)
        {
            var uid = HttpContext.Current.User.Identity.GetUserId();
            var currentRental = _context.OnlineRentals.Include(m => m.Movie).SingleOrDefault(m => m.User == uid && m.DateReturned == null && m.Id == id);
            if (currentRental == null)
                return NotFound();
            currentRental.Movie.Stock++;
            _context.OnlineRentals.Remove(currentRental);

            _context.SaveChanges();


            return Ok();
        }
    }

   
}
