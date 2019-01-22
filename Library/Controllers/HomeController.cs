using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        readonly LibraryContext _context;

        public HomeController(LibraryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        { 
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult AddUser(string fullName, string username, string email, string phoneNumber, string password)
        {
            Console.WriteLine($"Username is {username}");
            Console.WriteLine($"Email is {email}");
            Console.WriteLine("The form is triggering the post");
            User newUser = new User
            {
                FullName = fullName,
                Username = username,
                Email = email,
                PhoneNumber = phoneNumber,
                Password = password
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetObjectAsJson("newUser", newUser);

            return Redirect($"Profile/{newUser.Username}");
        }

        [HttpPost]
        public IActionResult VerifyUser(string email, string password)
        {
            Console.WriteLine($"Email is {email}");
            Console.WriteLine($"Password is {password}");
            Console.WriteLine("The form is triggering the post");

            User newUser = new User(); 
            newUser = _context.Users.Where(x => x.Email == email).Single();
            string dbPassword = newUser.Password;
            if (password == dbPassword)
            {
                HttpContext.Session.SetObjectAsJson("newUser", newUser);
            }
            return Redirect("/");
        }

        public IActionResult Profile(string username)
        {
            User newUser = HttpContext.Session.GetObjectFromJson<User>("newUser");
            @ViewData["newUser"] = newUser;
            return View(newUser);
        }

        public IActionResult AddABook()
        {
            User newUser = HttpContext.Session.GetObjectFromJson<User>("newUser");
            @ViewData["newUser"] = newUser;
            Console.WriteLine("newUser's Username is " + newUser.Username);

            return View(newUser);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
