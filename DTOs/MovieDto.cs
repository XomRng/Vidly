using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DTOs
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int MovieGenreId { get; set; }

        public MovieGenre MovieGenre { get; set; }

        [Required]
        //[ReleaseDateAbove1950]
        [Display(Name = "Data wyjscia filmu")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Data dodania")]
        public DateTime? DateAdded { get; set; }

        [Required]
        //[Range(0, 20, ErrorMessage = "Ilość musi być pomiędzy 0 a 20.")]
        [Display(Name = "Ilosc w magazynie")]
        public int NumberInStock { get; set; }

        [Required]
        [Display(Name = "Dostępna ilość")]
        public int NumberAvailable { get; set; }
    }
}