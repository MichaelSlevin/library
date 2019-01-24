//using System;
//using System.Collections.Generic;
//using NUnit.Framework;
//using Library.Models;

//namespace Library.Tests
//{
//    public class BookListSpec
//    {
//        readonly LibraryContext _context;

//        [Test(Description = "BookList has AllBooks collection")]
//        public void HasAllBooks()
//        {
//            // arrange
//            _context.Books.Add(new Book { Author = "Tanith Lee", Title = "To Indigo", ISBN = "929810929", OwnerId = 1, Available = true });
//            _context.SaveChanges();

//            // act
//            BookList bookList = new BookList(_context);

//            //assert
          
//        }
//    }
//}
