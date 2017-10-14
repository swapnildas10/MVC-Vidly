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
    public class SavedMoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public SavedMoviesController()
        {
            _context=new ApplicationDbContext();    
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/savedmovies")]
        public IHttpActionResult GetSavedItems()
        {
            var uid = HttpContext.Current.User.Identity.GetUserId();
            var saveditems = _context.SavedMovies.Include(m => m.Movie).Where(s => s.User == uid).ToList();
            if (saveditems.Count <= 0)
                return NotFound();
            List<SavedMoviesViewModel> savedMovies = new List<SavedMoviesViewModel>();
            foreach (SavedMovie savedMovie in saveditems)
            {
                savedMovies.Add(new SavedMoviesViewModel
                {
                    MovieId = savedMovie.Movie.Id,
                    Name = savedMovie.Movie.Name,
                    Stock = savedMovie.Movie.NumberAvailable
                });
            }

            return Ok(savedMovies);
        }
        [HttpGet]
        public IHttpActionResult GetSavedMovie(int id)
        {
            var uid = HttpContext.Current.User.Identity.GetUserId();
            var saveditem = _context.SavedMovies.Include(m => m.Movie).Single(s => s.User == uid && s.Movie.Id==id);
            SavedMoviesViewModel savedMoviesViewModel = new SavedMoviesViewModel
            {
                MovieId = saveditem.Movie.Id,
                Name = saveditem.Movie.Name,
                Stock = saveditem.Movie.NumberAvailable
            };
            return Ok(savedMoviesViewModel);
        }


        [System.Web.Http.HttpPut]
        public IHttpActionResult SaveMovie(int id)
        {
            var movie = _context.Movies.Single(m => m.Id == id);
            var uid = HttpContext.Current.User.Identity.GetUserId();
            var savedMovies = _context.SavedMovies.Include(m => m.Movie).Where(m => m.User == uid);
            if (savedMovies.Where(m => m.Movie.Id == id).ToList().Any())
                return Content(HttpStatusCode.Forbidden, "Duplicate Entry");

            _context.SavedMovies.Add(new SavedMovie
            {
                Movie = movie,
                User = uid
            });
            _context.SaveChanges();
            return Ok("Saved for Later");
        }
        [HttpDelete]
        public IHttpActionResult DeleteSavedMovie(int id)
        {
            var uid = HttpContext.Current.User.Identity.GetUserId();
            
            var dbsavedMovie = _context.SavedMovies.Include(m=>m.Movie).Single(m => m.User == uid && m.Movie.Id == id);
            
            _context.SavedMovies.Remove(dbsavedMovie);
            _context.SaveChanges();
            return Ok("Deleted");
        }
    }
}
