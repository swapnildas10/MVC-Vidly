using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
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
        public IHttpActionResult  UpdateRentals(int id, ReturnRentalDto returnRentalDto)
        {
            returnRentalDto.Id = id;
           var rentalsinDb= _context.Rentals.Single(r => r.Id == id);
            if (rentalsinDb.DateReturned !=null && returnRentalDto.DateReturned !=null  )
                if (rentalsinDb.DateReturned != returnRentalDto.DateReturned)
                    return BadRequest();
            if(returnRentalDto.DateReturned!=null)
            rentalsinDb.DateReturned = returnRentalDto.DateReturned;
            var customer = _context.Customers.Single(c=>c.Id==returnRentalDto.CustomerId);
            var movie = _context.Movies.Single(m => m.Id == returnRentalDto.MovieId);
            movie.NumberAvailable++;    
            rentalsinDb.Customer = customer;
            rentalsinDb.Movie = movie;
        //  Mapper.Map(returnRentalDto,rentalsinDb);
          //  rentalsinDb.Movie = Mapper.Map<MovieDto, Movie>(returnRentalDto.Movie);
          //  rentalsinDb.Customer = Mapper.Map<CustomerDto, Customer>(returnRentalDto.Customer);
            _context.SaveChanges();
            return Ok();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {

        }
    }
}