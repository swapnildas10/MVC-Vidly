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
    {   private const string API_KEY= "4520856e9bc4e97798334c0576400d36";
        ApplicationDbContext  _context;
        public MovieDetailsController()
        {
         _context = new ApplicationDbContext();   
        }
        // GET: MovieDetails
        [HttpGet]
        [Route("api/moviedetails/details/{id}")]
        public async  Task<IHttpActionResult> Description(int id)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("https://api.themoviedb.org");
                    var response = await client.GetAsync($"/3/movie/{id}?language=en-US&api_key="+API_KEY);
                    response.EnsureSuccessStatusCode();
                   
                    var youtubeResponse = await client.GetAsync($"/3/movie/{id}/videos?api_key="+API_KEY+"&language=en-US");
                    youtubeResponse.EnsureSuccessStatusCode();
                    var stringResult = await response.Content.ReadAsStringAsync();
                    var youtubeResult = await youtubeResponse.Content.ReadAsStringAsync();
                    var rawMovieDescription = JsonConvert.DeserializeObject<MovieDescription>(stringResult);
                    var youtubeResultDescription = JsonConvert.DeserializeObject<MovieTrailers>(youtubeResult);
                    return Ok(new
                    {
                        PgRated = rawMovieDescription.Adult,
                        Overview = rawMovieDescription.Overview,
                        ImdbId = rawMovieDescription.Imdb_Id,
                        ReleasedDate = rawMovieDescription.Release_Date,
                        Runtime = rawMovieDescription.RunTime,
                        ProductionCompanies = rawMovieDescription.Production_Companies,
                        Popularity = rawMovieDescription.Popularity,
                        Budget = rawMovieDescription.Budget,
                        Tagline = rawMovieDescription.Tagline,
                        Genres = rawMovieDescription.Genres,
                        HomePage = rawMovieDescription.Homepage,
                        Revenue = rawMovieDescription.Revenue,
                        Rating = rawMovieDescription.Vote_Average,
                       Videos = youtubeResultDescription.Results,
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
        [HttpGet]
        [Route("api/moviedetails/cast/{id}")]
        public async Task<IHttpActionResult> Cast(int id)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("https://api.themoviedb.org");
                    var response = await client.GetAsync($"/3/movie/{id}/credits?api_key="+ API_KEY);
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var rawMovieDescription = JsonConvert.DeserializeObject<MovieCast>(stringResult);
                    return Ok(new
                    {
                       Cast = rawMovieDescription.Cast,
                       Crew = rawMovieDescription.Crew
                    });
                }
                catch (HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error getting weather from TheMovieDb: {httpRequestException.Message}");
                }

            }
        }
        [HttpGet]
        [Route("api/moviedetails/search/{query}")]
        public async Task<IHttpActionResult> GetMovieById(string query = null)
        {
            using(var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("https://api.themoviedb.org");

                    var response = await client.GetAsync($"/3/search/movie?api_key="+API_KEY+"&language=en-US&query="+query+"&include_adult=true");
                    response.EnsureSuccessStatusCode();
                    var stringResult = await response.Content.ReadAsStringAsync();
                    var rawMovieDescription = JsonConvert.DeserializeObject<MovieSearch>(stringResult);
                    List<int> MovieId = new List<int>();
                    foreach (MovieDescription movieDescription in rawMovieDescription.Results)
                    {
                        MovieId.Add(movieDescription.Id);
                    }
                    
                    return Ok(rawMovieDescription);
                }
                catch (HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error getting weather from TheMovieDb: {httpRequestException.Message}");
                }

            }
             
        }
    }
   
}