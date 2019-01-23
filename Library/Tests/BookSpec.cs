using System;
using NUnit.Framework;
using Library.Models;

namespace Library.Tests
{
    public class BookSpec
    {
        [Test(Description = "Book has an author and title")]

        public void HasAuthorAndTitle()
        {
            // arrange
            Book book = new Book { Author = "J K Rowling", Title = "Harry Potter", ISBN = "1234567", OwnerId = 1, Available = true };
            // act

            // assert
            Assert.AreEqual(book.Author, "J K Rowling");
            Assert.AreEqual(book.Title, "Harry Potter");

        }
    }
}
