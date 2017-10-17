using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.Provider;

namespace Vidly.Models
{
    public class ReleaseDateAbove1950 : ValidationAttribute 
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var mov = (Movie) validationContext.ObjectInstance;

            return (mov.ReleaseDate.Value.Year > 1950) 
                ? ValidationResult.Success 
                : new ValidationResult("Data wydania filmu musi być powyżej 1950 roku");



        }
    }
}