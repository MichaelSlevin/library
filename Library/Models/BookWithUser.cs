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
        public string ISBN;
        public bool Available;
        public string FullName;
        public string Email;
        public string PhoneNumber;
        public string ImageUrl;
        public string Description;
        public string LinkToGoogleBooks;

        public BookWithUser(long Id, string Author, string Title, string ISBN, bool Available, string FullName, string Email, string PhoneNumber, string ImageUrl, string Description, string LinkToGoogleBooks)
        {
            this.Id = Id;
            this.Author = Author;
            this.Title = Title;
            this.ISBN = ISBN;
            this.Available = Available;
            this.FullName = FullName;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.ImageUrl = ImageUrl;
            this.Description = Description;
            this.LinkToGoogleBooks = LinkToGoogleBooks;
        }
    }
}
