using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MovieDto
    {
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //prevent identity insert exception
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

       
        [Required]
        public byte GenreId { get; set; }

        public GenreDto Genre { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        public string YoutubeId { get; set; }

       // [Range(1, 20)]
        [Required]
        public short Stock { get; set; }
    }
}