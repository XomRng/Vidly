using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MyUsersController : Controller
    {
        // GET: MyUsers
        private ApplicationDbContext _context;

        public MyUsersController()
        {
            _context = new ApplicationDbContext();
        }
        [Route("użytkownicy")]
        public ActionResult Index()
        {
            List<MyUser> users = _context.MyUsers.Include(u=>u.UserType).ToList();
            UserViewModel viewModel = new UserViewModel()
            {
                Users = users
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult SaveUser(UserViewModel viewModel)
        {

            return RedirectToAction("Index", "MyUsers");
        }

        public ActionResult EditUser()
        {
            return View("UserForm");
        }

        public ActionResult NewUser()
        {
            return View("UserForm");
        }

    }
}