using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class OnlineRentalsController : Controller
    {
        private ApplicationDbContext _context;

        public OnlineRentalsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: OnlineRentals
        public ActionResult Index()
        {
            var uid = HttpContext.User.Identity.GetUserId();

            return View();
        }
    }
}