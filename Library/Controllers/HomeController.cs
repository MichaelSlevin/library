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
            Console.WriteLine("Printing the empty session object---------------------------------------------");

            if(HttpContext.Session.GetObjectFromJson<User>("newUser") == null)
            {
              return View();
            }
            else
            {
              return Redirect("/Home/MyBookshelf");
            }

        }

        public IActionResult AddBooks()
        {
            if(HttpContext.Session.GetObjectFromJson<User>("newUser") == null)
            {
                return Redirect("/");
            }
            Console.WriteLine("In the barcode reader clas..................---------------------");

            return  View();
        }

        public IActionResult Register()
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

            return Redirect("/");
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

        public IActionResult MyBookshelf()
        {
            if(HttpContext.Session.GetObjectFromJson<User>("newUser") == null)
            {
                return Redirect("/");
            }
            long UserId = HttpContext.Session.GetObjectFromJson<User>("newUser").Id;
            Bookshelf newBookshelf = new Bookshelf(UserId, _context);
            return View(newBookshelf);
        }

        public IActionResult AddABook()
        {
            if(HttpContext.Session.GetObjectFromJson<User>("newUser") == null)
            {
                return Redirect("/");
            }
            User newUser = HttpContext.Session.GetObjectFromJson<User>("newUser");
            @ViewData["newUser"] = newUser;
            Console.WriteLine("newUser's Username is " + newUser.Username);
            return View(newUser);
        }

        [HttpPost]
        public IActionResult AddABook(string author, string title, string isbn, long ownerid)
        {
            _context.Books.Add(new Book { Author = author, Title = title, ISBN = isbn, OwnerId = ownerid, Available = true  });
            _context.SaveChanges();
            return Redirect("/Home/MyBookshelf");
        }

        public IActionResult EditUserDetails()
        {
            if (HttpContext.Session.GetObjectFromJson<User>("newUser") == null)
            {
                return Redirect("/");
            }
            User newUser = HttpContext.Session.GetObjectFromJson<User>("newUser");
            @ViewData["newUser"] = newUser;

            return View(newUser);
        }
        [HttpPost]
        public IActionResult EditUserDetails(long id, string fullName, string username, string email, string phoneNumber, string password)
        {
            if (HttpContext.Session.GetObjectFromJson<User>("newUser") == null)
            {
                return Redirect("/");
            }
            User newUser = HttpContext.Session.GetObjectFromJson<User>("newUser");
            @ViewData["newUser"] = newUser;

            newUser = _context.Users.Where(x => x.Id == id).Single();
            if (fullName != newUser.FullName)
            {
                newUser.FullName = fullName;
            }
            if (username != newUser.Username)
            {
                newUser.Username = username;
            }
            if (email != newUser.Email)
            {
                newUser.Email = email;
            }
            if (phoneNumber != newUser.PhoneNumber)
            {
                newUser.PhoneNumber = phoneNumber;
            }
            if (password != newUser.Password)
            {
                newUser.Password = password;
            }
            _context.Users.Update(newUser);
            _context.SaveChanges();

            HttpContext.Session.SetObjectAsJson("newUser", newUser);

            return Redirect("/Home/MyBookshelf");
        }

        public IActionResult FindABook()
        {
            if (HttpContext.Session.GetObjectFromJson<User>("newUser") == null)
            {
                return Redirect("/");
            }
            User newUser = HttpContext.Session.GetObjectFromJson<User>("newUser");
            @ViewData["newUser"] = newUser;

            var bookWithUser = (from book in _context.Books
                                join user in _context.Users
                                on book.OwnerId equals user.Id
                                select new
                                {
                                    Id = book.Id,
                                    Author = book.Author,
                                    Title = book.Title,
                                    Available = book.Available,
                                    FullName = user.FullName,
                                    Email = user.Email,
                                    PhoneNumber = user.PhoneNumber
                                }).ToList();

            List<BookWithUser> booksWithUser = new List<BookWithUser>();

            foreach (var book in bookWithUser)
            {
                booksWithUser.Add(new BookWithUser(book.Id, book.Author, book.Title, book.Available, book.FullName, book.Email, book.PhoneNumber));
            }
            BookList bookList = new BookList(_context, booksWithUser);

            return View(bookList);
        }

        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }

        [HttpPost]
        public IActionResult RemoveBook(long id, long userid)
        {
            _context.Remove(_context.Books.Single(a => a.Id == id));
            _context.SaveChanges();
            return Redirect("/Home/MyBookshelf");
        }

        [HttpPost]
        public IActionResult ChangeAvailability(long id, long userid, bool availability)
        {
            var book = _context.Books.First(a => a.Id == id);
            book.Available = availability;
            _context.SaveChanges();
            return Redirect("/Home/MyBookshelf");
        }

        public IActionResult addMultipleBooks1(string ISBNs)
        {
          string[] ISBNArray = ISBNs.Split(',');
          Console.WriteLine(ISBNs);
          foreach (var ISBN in ISBNArray)
          {
              Console.WriteLine("-----------------------------------------------------------");

              Console.WriteLine(ISBN);
          }
          return View();
        }

        [HttpPost]
        public IActionResult addMultipleBooks(string ISBNs, string Titles, string Authors)
        {
          // User newUser = HttpContext.Session.GetObjectFromJson<User>("newUser");
          long UserId = HttpContext.Session.GetObjectFromJson<User>("newUser").Id;
          Console.WriteLine("made it into add multiple Books post route");
          string[] ISBNArray = ISBNs.Split(',');
          string[] AuthorArray = Authors.Split(',');
          string[] TitleArray = Titles.Split(',');
          Console.WriteLine(ISBNs);

          for (var i = 1; i < ISBNArray.Length; i++)
          {
              Console.WriteLine("-----------------------------------------------------------");
              Console.WriteLine(TitleArray[i]);
              Console.WriteLine(AuthorArray[i]);
              Console.WriteLine(ISBNArray[i]);
               _context.Books.Add(new Book { Author = AuthorArray[i], Title = TitleArray[i], ISBN = ISBNArray[i], OwnerId = UserId, Available = true  });
          }
          _context.SaveChanges();
          return Redirect("/Home/MyBookshelf");
          // return Redirect("/");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
