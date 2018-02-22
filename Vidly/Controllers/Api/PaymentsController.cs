using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Vidly.Models;
using Vidly.Utils;

namespace Vidly.Controllers.Api
{
    public class PaymentsController : ApiController
    {
        private ApplicationDbContext _context = null;
        public PaymentsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody] PaymentData data)
        {
            // bug here 
            ChargeWithToken charge = new ChargeWithToken((long)(Convert.ToDouble(data.Amount)*100), data.Token);
            if (charge.PaymentResult() == EnumSuccessFail.SUCCESS)
            {
                var uid = HttpContext.Current.User.Identity.GetUserId();
                List<ShoppingCart> MovieList = _context.ShoppingCarts.Include(m => m.Movie).Where(s => s.User == uid).ToList();
                OnlineRentals onlineRentals = null;
                foreach ( ShoppingCart list in MovieList)
                {
                    onlineRentals = new OnlineRentals
                    {
                        DateRented = DateTime.Now,
                        DateReturned = null,
                        Movie = list.Movie,
                        User = uid
                        
                    };
                    _context.ShoppingCarts.Remove(list);
                    _context.OnlineRentals.Add(onlineRentals);
                }

                _context.SaveChanges();
                return Ok();
            }

            else
            {
                return Content(HttpStatusCode.BadRequest, "Payment Failed");
            }
        }

        // PUT api/<controller>/5
        public void Put(int id,  string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}