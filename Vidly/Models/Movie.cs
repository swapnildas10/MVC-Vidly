using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
           // [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //prevent identity insert exception
            public int Id { get; set; }

            [Required]
            public string Name { get; set; }
    
            public Genre Genre { get; set; }

            [Display(Name = "Genre")]
            [Required]
            public byte GenreId { get; set; }

            [Display(Name = "Release Date")]
            [Required]
            public DateTime ReleaseDate { get; set; }

            [Required]
            public DateTime DateAdded { get; set; }

        
        [Display(Name = "Number in Stock")]
        [Range(1,20)]
        [Required]
        public short Stock { get; set; }
        //prop

        public short NumberAvailable { get; set; }

    }


}