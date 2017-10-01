using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MovieTrailers
    {
        public int Id { get; set; }
        public MovieVideos[] Results { get; set; }
    }
}