﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class ReturnRentalDto
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public CustomerDto Customer { get; set; }

        
        public MovieDto Movie { get; set; }
        [Required]
        public int MovieId { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
    }
}