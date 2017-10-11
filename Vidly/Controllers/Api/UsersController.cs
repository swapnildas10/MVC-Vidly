using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class UsersController : ApiController
    {
        ApplicationDbContext _context;
        public UsersController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetUsers(string email = null)
        {

          if(_context.Users.Any(u=>u.Email==email))
            return Ok("Email Exists");
            return Ok("Email Available");
        }

    }
}
