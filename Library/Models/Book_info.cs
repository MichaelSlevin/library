using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Book_info
    {
        [Key]
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string LinkToGoogleBooks { get; set; }
    }
}
