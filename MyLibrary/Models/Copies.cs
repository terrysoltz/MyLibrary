﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyLibrary.Models
{
    public class Copies
    {
        public int CopiesID { get; set; }
        public int BookID { get; set; }
        public int BranchID { get; set; }

        [Display(Name = "Copies Available")]
        public int NoCopies { get; set; }

        public virtual Book Book { get; set; }
        public virtual Branch Branch { get; set; }
    }
}