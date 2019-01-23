using System;
using NUnit.Framework;
using Library.Models;

namespace Library.Tests
{
    public class BookshelfSpec
    {
        [Test(Description = "Bookshelf")]

        public void HasAUsersBooks()
        {
            // arrange
            User user = new User
            {
                FullName = "Test User",
                Username = "TestUser",
                Email = "Email@Email.com",
                PhoneNumber = "0788161523715",
                Password = "password"
            };

            Book book = new Book { Author = "J K Rowling", Title = "Harry Potter", ISBN = "12345679345", OwnerId = 1, Available = true };
            Book book2 = new Book { Author = "George R R Martin", Title = "A Game of Thrones", ISBN = "3627289464", OwnerId = 1, Available = true }

            // act

            // assert


        }
    }
}

