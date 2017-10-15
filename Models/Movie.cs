using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public MovieGenre MovieGenre { get; set; }

        [Required]
        public int MovieGenreId { get; set; }

        [Required]
        [Display(Name = "Data wyjscia filmu")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Data dodania")]
        public DateTime? DateAdded { get; set; }

        [Required]
        [Display(Name = "Ilosc w magazynie")]
        public int NumberInStock { get; set; }


        // //movies/random


     

    }
}