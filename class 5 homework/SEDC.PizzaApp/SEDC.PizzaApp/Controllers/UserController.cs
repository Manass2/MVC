using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.Mappers;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            List<User> users = StaticDb.Users;
            List<UserViewModel> UserViewModels = new List<UserViewModel>();

            foreach (var user in users)
            {
                UserViewModels.Add(UserMapper.ToUserViewModel(user));
            }
            return View(UserViewModels);
        }

        public IActionResult Details(int? id) // localhost:port/Pizza/Details/1 or  localhost:port/Pizza/Details
        {
            if (id == null)
            {
                return View("BadRequest");
            }

            User user = StaticDb.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return View("ResourceNotFound");
            }

            UserViewModel userViewModel = UserMapper.ToUserViewModel(user);

            return View(userViewModel);
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            UserViewModel userViewModel = new UserViewModel();
            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult CreateUserPost(UserViewModel userView)
        {
            userView.Id = ++StaticDb.UserId;

            StaticDb.Users.Add(UserMapper.ToUser(userView));
            return RedirectToAction("Index");
        }

        public IActionResult EditUser(int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }
            User user = StaticDb.Users.FirstOrDefault(p => p.Id == id);
            if (user == null)
            {
                return View("ResourceNotFound");
            }
            UserViewModel userViewModel = UserMapper.ToUserViewModel(user);

            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult EditUserPost(UserViewModel userViewModel)
        {
            User user = StaticDb.Users.FirstOrDefault(x => x.Id == userViewModel.Id);
            User editedUser = UserMapper.ToUser(userViewModel);
            int i = StaticDb.Users.IndexOf(user);
            StaticDb.Users[i] = editedUser;

            return RedirectToAction("Index");
        }

        public IActionResult DeleteUser(int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }

            Order userOrder = StaticDb.Orders.FirstOrDefault(p => p.User.Id == id);
            if (userOrder != null)
            {
                return View("ObjectInUse");
            }
            User user = StaticDb.Users.FirstOrDefault(x => x.Id == id); ;
            UserViewModel userViewModel = UserMapper.ToUserViewModel(user);

            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult DeleteUserPost(UserViewModel userViewModel)
        {
            var index = StaticDb.Users.FindIndex(x => x.Id == userViewModel.Id);

            if (index == -1)
                return View("ResourceNotFound");

            StaticDb.Users.RemoveAt(index);
            return RedirectToAction("Index");
        }
    }
}
 
 