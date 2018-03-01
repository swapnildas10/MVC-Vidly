using System.Web.Mvc;

namespace Vidly.Controllers
{
    public class FavoritesController : Controller
    {
        // GET: Favorates
        public ActionResult MyFavorites()
        {
            return View();
        }
    }
}