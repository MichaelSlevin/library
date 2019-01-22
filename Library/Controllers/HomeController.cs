using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library.Models;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            User newUser = new User
            {
                FullName = "test user",
                Username = "testUser1",
                Email = "test@test.com",
                PhoneNumber = "12345",
                Password = "abcde"
            };

            HttpContext.Session.SetObjectAsJson("newUser", newUser);
            return View(newUser);
        }

        public IActionResult AddABook()
        {
            User newUser = HttpContext.Session.GetObjectFromJson<User>("newUser");
            @ViewData["newUser"] = newUser;
            Console.WriteLine("newUser's Username is " + newUser.Username);

            return View(newUser);
        }

        public IActionResult SignUp()
        {
            ViewData["Message"] = "Please complete the following fields";

            return View();
        }

        public IActionResult AllBooks()
        {
            ViewData["Message"] = "All books in the library";

            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

     
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
