using System;
using NUnit.Framework;
using Library.Models;

namespace Library.Tests
{
    public class UserSpec
    {
        [Test(Description = "User has details")]

        public void HasDetails()
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
            Assert.AreEqual(user.FullName, "Test User");
            Assert.AreEqual(user.Username, "TestUser");
            Assert.AreEqual(user.Email, "Email@Email.com");
            Assert.AreEqual(user.PhoneNumber, "0788161523715");
            Assert.AreEqual(user.Password, "password");
        }
    }
}
