using System;
using NUnit.Framework;
using Library.Models;

namespace Library.Tests
{
    public class UserSpec
    {
        [Test(Description = "User has a Username")]

        public void HasUsername()
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
            // act

            // assert
            Assert.AreEqual(user.Username, "TestUser");
        }
    }
}
