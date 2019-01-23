using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
    public class BookWithUser
    {
        public long Id;
        public string Author;
        public string Title;
        public bool Available;
        public string FullName;
        public string Email;
        public string PhoneNumber;

        public BookWithUser(long Id, string Author, string Title, bool Available, string FullName, string Email, string PhoneNumber)
        {
            this.Id = Id;
            this.Author = Author;
            this.Title = Title;
            this.Available = Available;
            this.FullName = FullName;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
        }
    }
}
