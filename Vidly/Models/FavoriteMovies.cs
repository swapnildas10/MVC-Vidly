using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class FavoriteMovies
    {
        public int Id { get; set; }
        [Required]
        public string User { get; set; }

        [Required]
        public Movie Movie { get; set; }

        
    }
}