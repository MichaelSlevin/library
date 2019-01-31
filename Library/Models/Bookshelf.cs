//
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
    public class Bookshelf
    {
        readonly LibraryContext _context;
        public IEnumerable<BookWithInfo> AvailableBooks;
        public IEnumerable<BookWithInfo> UnavailableBooks;
        public List<BookWithInfo> BooksWithInfo;



        public User Owner;
        public long UserId;
        public bool NoAvailableBooks = true;
        public bool NoUnavailableBooks = true;

        public Bookshelf(long userid, LibraryContext context, List<BookWithInfo> booksWithInfo)
        {

            this.UserId = userid;
            this._context = context;
            var books =  this._context.Books.ToList();
            var bookinfos = this._context.Book_info.ToList();

            this.BooksWithInfo = booksWithInfo.ToList();
            this.AvailableBooks = this.BooksWithInfo.Where(book => book.OwnerId == userid && book.Available == true);
            this.UnavailableBooks = this.BooksWithInfo.Where(book => book.OwnerId == userid && book.Available == false);
            if (this.AvailableBooks.Count() > 0 )
            {
              this.NoAvailableBooks = false;
            }
            if (this.UnavailableBooks.Count() > 0 )
            {
              this.NoUnavailableBooks = false;
            }


            // List<BookWithInfo> newList = new List<BookWithInfo>();

            // foreach(var b in bookWithInfo)
            // {
            //   // Console.WriteLine(b.ImageUrl);
            //   Console.WriteLine(b.Id);
            //   Console.WriteLine(b.Author);
            //   Console.WriteLine(b.Title);
            //   Console.WriteLine(b.ISBN);
            //   Console.WriteLine(b.Available);
            //   Console.WriteLine(b.ImageUrl);
            //   Console.WriteLine(b.Description);
            //   Console.WriteLine(b.LinkToGoogleBooks);
            //   var b1 = new BookWithInfo(b.Id, b.Author, b.Title, b.ISBN, b.Available, b.ImageUrl, b.Description, b.LinkToGoogleBooks);
            //   Console.WriteLine(b1.ISBN);
            //   Console.WriteLine("----------------------");
            //   newList.Add(b1);
            //   Console.WriteLine(newList.Length());
            //   // var b1 = new BookWithInfo(b.Id, b.Author, b.Title, b.ISBN, b.Available, b.ImageUrl, b.Description, b.LinkToGoogleBooks);
            //   // // this.BooksWithInfo.Add(new BookWithInfo(b.Id, b.Author, b.Title, b.ISBN, b.Available, b.ImageUrl, b.Description, b.LinkToGoogleBooks));
            //   // this.BooksWithInfo.Add(b1);
            // }

        }
        public IEnumerable<BookWithInfo> getBooksWithInfo()
        {
          return this.BooksWithInfo;
        }
        public IEnumerable<BookWithInfo> getAvailableBooks()
        {
          return this.AvailableBooks;
        }
        public IEnumerable<BookWithInfo> getUnavailableBooks()
        {
          return this.UnavailableBooks;
        }



    }
}
