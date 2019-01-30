using System;
using System.Collections;
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
        public List<Book_info> bookInfos;
        public IEnumerable<Book> myBooks;
        public bool NoAvailableBooks = true;
        public bool NoUnavailableBooks = true;
        ArrayList myISBNArray = new ArrayList();

        public Bookshelf(long userid, LibraryContext context)
        {

            this.UserId = userid;
            this._context = context;
            var books =  this._context.Books.ToList();
            this.bookInfos = this._context.Book_info.ToList();
            this.myBooks = books.Where(book => book.OwnerId == userid);

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

            var books1 = _context.Set<Book>().AsQueryable();
            var book_info1 = _context.Set<Book_info>().AsQueryable();
            var resList = books1.GroupJoin(book_info1, book => book.ISBN, book_info => book_info.ISBN, (a, b) => new { Book = a, Book_info = b.DefaultIfEmpty() }).SelectMany(obj => obj.Book_info.Select(b => new { Book = obj.Book.Title, Book_info = b.ImageUrl })).ToList();
            foreach(var i in resList)
            {
                Console.WriteLine(i.Book);
                Console.WriteLine(i.Book_info);

            }
            //var resList1 = _context.Set<Book>().AsQueryable().Include(a => a.ISBN.Select(b => b.ISBN)).ToList();

        }

        public IEnumerable<Book> getAvailableBooks()
        {
          return this.AvailableBooks;
        }

        public IEnumerable<Book> getUnavailableBooks()
        {
          return this.UnavailableBooks;
        }

        public ArrayList getMyISBNs()
        {
            foreach (var book in myBooks)
            {
                myISBNArray.Add(book.ISBN);
            }
            return myISBNArray; 
        }

        //public IEnumerable<Book_info> getUserBookInfo
        //{ 
       

        ////var resList = authurs.GroupJoin(books, authur => authur.Id, book => book.AuthorId, (a, b) => new { Author = a, Book = b.DefaultIfEmpty() }).SelectMany(obj => obj.Book.Select(b => new { Author = obj.Author.Name, Book = b.Name })).ToList();
        //}

    }
}
