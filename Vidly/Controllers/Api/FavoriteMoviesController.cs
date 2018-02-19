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
    public class FavoriteMoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public FavoriteMoviesController()
        {
            _context = new ApplicationDbContext();
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetFavoriteMovies()
        {
            var uid = HttpContext.Current.User.Identity.GetUserId();
            var saveditems = _context.FavoriteMovies.Include(s => s.Movie).Where(s => s.User == uid).ToList();
            if (saveditems.Count <= 0)
                return NotFound();
            List<FavoriteMoviesVIewModel> FavoriteMovies = new List<FavoriteMoviesVIewModel>();
            foreach (FavoriteMovies favMovie in saveditems)
            {
                FavoriteMovies.Add(new FavoriteMoviesVIewModel
                {
                    Movie = favMovie.Movie,
                    Name = favMovie.Movie.Name,
                    Stock = favMovie.Movie.NumberAvailable
                });
            }

            return Ok(FavoriteMovies);
        }
        [HttpGet]
        public IHttpActionResult GetFavoriteMovie(int id)
        {
            var uid = HttpContext.Current.User.Identity.GetUserId();
            var favMovie = _context.FavoriteMovies.Include(m => m.Movie).SingleOrDefault(s => s.User == uid && s.Movie.Id == id);
            if (favMovie == null)
                return NotFound();
            FavoriteMoviesVIewModel FavoriteMovies = new FavoriteMoviesVIewModel
            {
                Movie = favMovie.Movie,
                Name = favMovie.Movie.Name,
                Stock = favMovie.Movie.NumberAvailable
            };
            return Ok(FavoriteMovies);
        }
        [HttpGet]
        [Route("api/isOwnedFavorite/{id}")]
        public IHttpActionResult isOwnedFavoriteMovie(int id)
        {
            var uid = HttpContext.Current.User.Identity.GetUserId();
            var favMovie = _context.FavoriteMovies.Include(m => m.Movie).Single(s => s.User == uid && s.Movie.Id == id);
            if (favMovie == null)
                return Ok(false);
            var isOwned = _context.OnlineRentals.Include(m => m.Movie).Count(s => s.User == uid && s.Movie.Id == id && s.Movie.Id == favMovie.Movie.Id);
            if (isOwned == 0)
                return Ok(false);
            else
                return Ok(true);



        }


        [System.Web.Http.HttpPut]
        public IHttpActionResult SaveFavMovie(int id)
        {
            var movie = _context.Movies.Single(m => m.Id == id);
            var uid = HttpContext.Current.User.Identity.GetUserId();
            var favMovie = _context.FavoriteMovies.Include(m => m.Movie).Where(m => m.User == uid);
            if (favMovie.Where(m => m.Movie.Id == id).ToList().Any())
                return Content(HttpStatusCode.Forbidden, "Duplicate Entry");

            _context.FavoriteMovies.Add(new FavoriteMovies
            {
                Movie = movie,
                User = uid
            });
            _context.SaveChanges();
            return Ok("Saved for Later");
        }
        [HttpDelete]
        public IHttpActionResult DeleteFavMovie(int id)
        {
            var uid = HttpContext.Current.User.Identity.GetUserId();

            var favMovie = _context.FavoriteMovies.Include(m => m.Movie).Single(m => m.User == uid && m.Movie.Id == id);

            _context.FavoriteMovies.Remove(favMovie);
            _context.SaveChanges();
            return Ok("Deleted");
        }
    }
}

