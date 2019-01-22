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
        readonly LibraryContext _context;

        public HomeController(LibraryContext context)
        {
            _context = context;
        }

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
            _context.Users.Add(newUser);
            _context.SaveChanges();

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

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MyBookshelf()
        {
            long UserId = HttpContext.Session.GetObjectFromJson<User>("newUser").Id;
            // long Books = _context.Users.Where(x => x.Username == username).Select(x => x.Id).First();
            Bookshelf newBookshelf = new Bookshelf(UserId, _context);
            return View(newBookshelf);
        }

        [HttpPost]
        public IActionResult AddABook(string author, string title, string isbn, long ownerid)
        {
            _context.Books.Add(new Book { Author = author, Title = title, ISBN = isbn, OwnerId = ownerid, Available = true  });
            _context.SaveChanges();
            return Redirect("/Home/AddABook");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
