using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

using Newtonsoft.Json;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MovieDetailsController : ApiController
    {
        ApplicationDbContext  _context;
        public MovieDetailsController()
        {
         _context = new ApplicationDbContext();   
        }
        // GET: MovieDetails
        [HttpGet]
        public async  Task<IHttpActionResult> Description(int id)
        {

            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("https://api.themoviedb.org");
                    var response = await client.GetAsync($"/3/movie/{id}?api_key=4520856e9bc4e97798334c0576400d36");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var rawMovieDescription = JsonConvert.DeserializeObject<MovieDescription>(stringResult);
                    return Ok(new
                    {
                        PgRated = rawMovieDescription.Adult,
                        Overview = rawMovieDescription.Overview,
                        ReleasedDate = rawMovieDescription.Release_Date,
                        Runtime = rawMovieDescription.RunTime,
                        
                       
                        Rating = rawMovieDescription.Vote_Average,
                       
                        VoteCount = rawMovieDescription.Vote_Count,
                         PosterPath = rawMovieDescription.Poster_Path
                       
                    });
                }
                catch (HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error getting weather from TheMovieDb: {httpRequestException.Message}");
                }

            }
        }
    }
}