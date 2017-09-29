using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MovieCast
    {
        public int Id { get; set; }
         
         
        public Cast[] Cast { get; set; }
        public Crew[] Crew { get; set; }
    }
}