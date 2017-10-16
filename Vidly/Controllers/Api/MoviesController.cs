using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;
using System.Web;
using System.Web.Routing;
using Vidly.Controllers.Api.Filter;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
       [HttpGet]
        // GET: api/Movies
        public IHttpActionResult GetMovies(int? page  ,string query = null)
        {//.Where(m => m.NumberAvailable > 0)
            var moviesQuery = _context.Movies.Include(c => c.Genre);//deferred execution here
            if(!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));
            if (page.HasValue)
                moviesQuery = moviesQuery.OrderBy(m=>m.Name).Skip((12 * (page.Value - 1))).Take((12));//deferred execution here

            var movieDtos = moviesQuery.Include(c=>c.Genre).ToList().Select(Mapper.Map<Movie,MovieDto>);
            return Ok(movieDtos);

        }
        [HttpGet]
        [Route("api/movies/allmovies")]
        public IHttpActionResult GetAllMovies( string query = null)
       {//.Where(m => m.NumberAvailable > 0)
            var moviesQuery = _context.Movies.Include(c => c.Genre);//deferred execution here
            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));
            
            var movieDtos = moviesQuery.Include(c => c.Genre).OrderBy(m => m.Name).ToList().Select(Mapper.Map<Movie, MovieDto>);
            return Ok(movieDtos);

        }
        [HttpGet]
        [Route("api/movies/pages")]
        public IHttpActionResult GetPages()
        {
            var count = _context.Movies.Count();
            float pages = (float)count / 12;
            return Ok(Math.Ceiling(pages));
        }


        [HttpGet]
        // GET: api/Movies/5
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return NotFound();
            return Ok(Mapper.Map<Movie,MovieDto>(movie));
        }
        [HttpPost]
        // POST: api/Movies
       [BasicAuthentication]
        //[Authorize(Roles = RoleName.CanManageMovies)]
        [CanManageRole(RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }
        [HttpPut]
         
        [Authorize(Roles = RoleName.CanManageMovies)]
        // PUT: api/Movies/5
        public void UpdateMovie(int id, MovieDto moveDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movieInDb = _context.Movies.SingleOrDefault(c=>c.Id == id);
            if(movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(moveDto, movieInDb);

            _context.SaveChanges();


        }
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        // DELETE: api/Movies/5
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if(movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

        }
    }
}
