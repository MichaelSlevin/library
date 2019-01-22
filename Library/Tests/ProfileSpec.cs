using System;
using NUnit.Framework;
using Library.Models;

namespace Library.Tests
{
    public class ProfileSpec
    {
        [Test(Description = "Profile has a Username")]

        public void HasUsername()
        {
            // arrange
            Profile profile = new Profile("User 1");
            // act

            // assert
            Assert.AreEqual(profile.Username, "User 1");
        }
    }
}
