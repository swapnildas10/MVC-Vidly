﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MovieDescription
    {
        public int Id { get; set; }

        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        [Display(Name = "PG-Rating")]
        [Required]
        public bool Adult { get; set; }

        [Display(Name = "Overview")]
        [Required]
        public string Overview { get; set; }

        [Display(Name = "Released Date")]
        [Required]
        public DateTime Release_Date { get; set; }

        [Display(Name = "Runtime")]
        [Required]
        public int RunTime { get; set; }

        [Display(Name = "Rating")]
        [Required]
        public float Vote_Average { get; set; }

        [Display(Name = "Total Votes")]
        [Required]
        public int Vote_Count { get; set; }

        [Display(Name = "Poster Path")]
        public string Poster_Path { get; set; }
        
    }
}