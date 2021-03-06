﻿using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{

    public class CustomersController : ApiController

    {
        private readonly ApplicationDbContext _context;
        //ctor
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/customers
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customerquery = _context.Customers.Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customerquery = customerquery.Where(c => c.Name.Contains(query));
            var customerDtos = customerquery.ToList().
                Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }
        
        //GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
                    return Ok(Mapper.Map<Customer,CustomerDto>(customer));
        }

        [HttpPost]
        //POST  /api/customers
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id),customerDto );

        }
        //PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto,customerInDb);
            
            _context.SaveChanges();
        }
        
        [HttpDelete]
        //DELETE /api/customers/1
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }

       

    }
}
