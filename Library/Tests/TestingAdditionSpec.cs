using System;
using NUnit.Framework;
using Library.Models;

namespace Library.Tests
{
    [TestFixture]
    public class Testing_addition
    {
        //public EmptyClass()
        //{
        //}
        [Test(Description = "1=1")]
        public void Testing_addition1()
        {
        //arrange


        //act

        //assert
        Assert.AreEqual(2, 1+1);
        }
    }
}
