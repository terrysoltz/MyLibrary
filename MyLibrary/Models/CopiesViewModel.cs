using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLibrary.Models
{
    public class CopiesViewModel
    {
        public IEnumerable<Copies> Copies { get; set; }
        public IEnumerable<BookAuthor> Authors { get; set; }
    }
}