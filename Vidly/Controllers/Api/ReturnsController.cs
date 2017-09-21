using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class ReturnsController : ApiController
    {
        private ApplicationDbContext _context;
        public ReturnsController()
        {
            _context = new ApplicationDbContext();
        }
        // PUT api/Returns
        [HttpPut]
        public IHttpActionResult Returns(NewRentalDto returnrentalDto)
        {
           
            var rentals = _context.Rentals.Where(r => r.Customer.Id == returnrentalDto.CustomerId);
                  foreach (var rental in rentals)
            {
                if (returnrentalDto.MovieIds.Contains(rental.Movie.Id))
                {
                    rental.DateReturned = DateTime.Now;
                } 
            }
            _context.SaveChanges();
            
            return Ok();
        }
        //GET api/Returns
       [HttpGet]
        public IHttpActionResult RentalCustomers(string customerName = null)
       {
           var rentalQuery = _context.Rentals.Include(r=>r.Customer).Include(r=>r.Movie);
           if (!String.IsNullOrWhiteSpace(customerName))
               rentalQuery = rentalQuery.Where(r => r.Customer.Name.Contains(customerName));
           var rentalDtos = rentalQuery.ToList().Select(Mapper.Map<Rental,ReturnRentalDto>);
            
            return Ok(rentalDtos);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/Rentals/
        [HttpPut]
        public IHttpActionResult  Put(int id, ReturnRentalDto returnRentalDto)
        {   
            return Ok();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}