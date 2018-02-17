using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class FavoriteMoviesVIewModel
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public Movie Movie { get; set; }
         
    }
}