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
    }

   
}
