using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Models
{
    public class BookAuthor
    {
        public int BookAuthorID { get; set; }
        public int BookID { get; set; }

        [Display(Name = "Author")]
        public string Name { get; set; }

        public virtual Book Book { get; set; }
    }
}