
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
        public IEnumerable<Book> my_books;
        public User Owner;
        public long UserId;
        public Bookshelf(long userid, LibraryContext context)
        {
            this.UserId = userid;
            this._context = context;
            var books =  this._context.Books.ToList();
            this.my_books = books.Where(book => book.OwnerId == userid);
            Console.WriteLine(my_books);
            Console.WriteLine(my_books.First());
        }
        public IEnumerable<Book> getBooks()
        {
          return this.my_books;
        }
    }
}
