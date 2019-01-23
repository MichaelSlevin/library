using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
    public class BookList
    {
        readonly LibraryContext _context;
        public IEnumerable<Book> AllBooks;

        public BookList(LibraryContext context)
        {
            this._context = context;
            this.AllBooks = this._context.Books.ToList();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return this.AllBooks;
        }

    }
}
