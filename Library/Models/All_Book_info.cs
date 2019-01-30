
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
    public class All_Book_info
    {
        readonly LibraryContext _context;
        public IEnumerable<Book_info> AllBookInfo;

        public All_Book_info(LibraryContext context)
        {

            this._context = context;
            this.AllBookInfo = this._context.Book_info.ToList();

        }
        public IEnumerable<Book_info> getAllBookInfo()
        {
          return this.AllBookInfo;
        }

        public bool ContainsBook(string ISBN)
        {
          var bookToFind = this.AllBookInfo.Where(book => book.ISBN == ISBN);

          if (bookToFind.Count() > 0 )
          {
            return true;
          }
          return false;
        }

        // GetAuthor

        public string GetAuthor(string ISBN)
        {
          var bookToFind = this.AllBookInfo.Where(book => book.ISBN == ISBN).First();

          return bookToFind.Author;

        }

        //GetTitle

        public string GetTitle(string ISBN)
        {
          var bookToFind = this.AllBookInfo.Where(book => book.ISBN == ISBN).First();

          return bookToFind.Title;

        }

        //GetImageUrl

        public string GetImageUrl(string ISBN)
        {
          var bookToFind = this.AllBookInfo.Where(book => book.ISBN == ISBN).First();

          return bookToFind.ImageUrl;

        }

        public string allISBNs()
        {
          var ISBNs = String.Join(',',this.AllBookInfo.Select(l => l.ISBN).ToList());
          return ISBNs;
        }
    }
}
