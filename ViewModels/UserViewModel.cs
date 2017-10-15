using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class UserViewModel
    {
        public MyUser MyUser { get; set; }
        public List<UserType> UserTypes { get; set; }
        public List<MyUser> Users { get; set; }

    }
}