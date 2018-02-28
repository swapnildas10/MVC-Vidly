using System;
using System.ComponentModel.DataAnnotations;

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

        [Required]
        
        public int MovieDb { get; set; }

        // [Range(1, 20)]
        [Required]
        public short Stock { get; set; }

        [Required]
        public decimal Cost { get; set; }
    }
}