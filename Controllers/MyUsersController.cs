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
        [ValidateAntiForgeryToken]
        public ActionResult SaveUser(MyUser viewModel)
        {
            if (!ModelState.IsValid)
            {
                var localViewModel = new UserViewModel(viewModel)
                {
                    UserTypes = _context.MyUserTypes.ToList()
                };
                return View("UserForm", localViewModel);
            }

            if (viewModel.Id == 0)
            {
                _context.MyUsers.Add(viewModel);
            }
            else
            {
                MyUser usr = _context.MyUsers.Single(u => u.Id == viewModel.Id);

                usr.Name = viewModel.Name;
                usr.Login = viewModel.Login;
                usr.Password = viewModel.Password;
                usr.UserTypeId = viewModel.UserTypeId;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "MyUsers");
        }

        public ActionResult EditUser(int id)
        {
            MyUser user = _context.MyUsers.Single(u => u.Id == id);

            UserViewModel viewModel = new UserViewModel(user)
            {           
                UserTypes =  _context.MyUserTypes.ToList()
            };
            

            return View("UserForm", viewModel);
        }

        public ActionResult NewUser()
        {
            UserViewModel viewModel = new UserViewModel()
            {
                UserTypes = _context.MyUserTypes.ToList()
            };

            return View("UserForm", viewModel);
        }

    }
}