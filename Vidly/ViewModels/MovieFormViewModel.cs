using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Vidly.Migrations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //prevent identity insert exception
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

       
        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

       

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [Required]
        public short? Stock { get; set; }
        //prop public IEnumerable<Genre> Genres { get; set; }
        [Display(Name = "Youtube ID")]
        public string YoutubeId { get; set; }

        [Required]
        [Display(Name = "MovieDb ID")]
        public int MovieDb { get; set; }
        public string Title
        {
            get
            {
                if (Id != 0)
                {
                    return "Edit Movie";
                }
                else
                {
                    return "New Movie";
                }
            }
        }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0.00, 10.00)]
        [Display(Name = "Rate per day")]
        public decimal Cost { get; set; }

        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            Stock = movie.Stock;
            GenreId = movie.GenreId;
           YoutubeId= movie.YoutubeId;
            MovieDb = movie.MovieDb;
            Cost = movie.Cost;
        }

    }
}