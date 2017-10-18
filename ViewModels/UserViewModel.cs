using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class UserViewModel
    {
       // public MyUser MyUser { get; set; }
        public List<UserType> UserTypes { get; set; }
        public List<MyUser> Users { get; set; }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        [StrongPassword]
        public string Password { get; set; }
        [Required]
        public int? UserTypeId { get; set; }

 

        public UserViewModel(MyUser user)
        {
            Id = user.Id;
            Name = user.Name;
            Login = user.Login;
            Password = user.Password;
            UserTypeId = user.UserTypeId;
        }

        public UserViewModel()
        {
            Id = 0;
        }

    }
}