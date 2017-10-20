using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DTOs
{
    public class MyUserDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        [StrongPassword]
        public string Password { get; set; }
        [Required]
        public int UserTypeId { get; set; }

 
    }
}