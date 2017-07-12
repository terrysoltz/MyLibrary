using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLibrary.Models
{
    public class LoanViewModel
    {
        public Copies Copies { get; set; }
        public Loan Loan { get; set; }
    }
}