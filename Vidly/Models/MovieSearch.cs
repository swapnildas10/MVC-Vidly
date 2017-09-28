using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MovieSearch
    {
        public int Id { get; set; }
        public int PageNo { get; set; }
        public MovieDescription[] Results { get; set; }
        public int Total_Results { get; set; }
        public int Total_Pages { get; set; }
    }
}