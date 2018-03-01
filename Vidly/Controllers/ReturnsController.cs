using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class ReturnsController : Controller
    {
        public ReturnsController()
        {
        }
        // GET: Returns
        public ActionResult Returns()
        {

            return View();
        }
    }
}