using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class StockBetween1To20 : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie) validationContext.ObjectInstance;
            if(movie.Stock >= 1 && movie.Stock <=20)
                return ValidationResult.Success;
            else
            {
                return new ValidationResult("Stock numbers should be between 1 and 20");
            }
        }
    }
}