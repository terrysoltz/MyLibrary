using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLibrary.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string PublisherName { get; set; }

        public virtual Publisher Publisher { get; set; }
    }
}