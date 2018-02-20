using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class ReturnsController : Controller
    {
        public ReturnsController()
        {
            ApplicationDbContext _context;
        }
        // GET: Returns
        public ActionResult Returns()
        {

            return View();
        }
    }
}