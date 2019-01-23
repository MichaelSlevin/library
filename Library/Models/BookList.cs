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
        public List<BookWithUser> AllBooksWithUser;
        

        public BookList(LibraryContext context, List<BookWithUser> booksWithUser)
        {
            this._context = context;
            this.AllBooksWithUser = booksWithUser;
        }

        public IEnumerable<BookWithUser> GetAllBooksWithUser()
        {
            return this.AllBooksWithUser;
        }
    }
}
