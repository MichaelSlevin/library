
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
    public class Bookshelf
    {
        readonly LibraryContext _context;
        public IEnumerable<Book> AvailableBooks;
        public IEnumerable<Book> UnavailableBooks;

        public User Owner;
        public long UserId;
        public bool NoAvailableBooks = true;
        public bool NoUnavailableBooks = true;

        public Bookshelf(long userid, LibraryContext context)
        {

            this.UserId = userid;
            this._context = context;
            var books =  this._context.Books.ToList();
            this.AvailableBooks = books.Where(book => book.OwnerId == userid && book.Available == true);
            this.UnavailableBooks = books.Where(book => book.OwnerId == userid && book.Available == false);

            if (this.AvailableBooks.Count() > 0 )
            {
              this.NoAvailableBooks = false;
            }
            if (this.UnavailableBooks.Count() > 0 )
            {
              this.NoUnavailableBooks = false;
            }

        }
        public IEnumerable<Book> getAvailableBooks()
        {
          return this.AvailableBooks;
        }
        public IEnumerable<Book> getUnavailableBooks()
        {
          return this.UnavailableBooks;
        }



    }
}
