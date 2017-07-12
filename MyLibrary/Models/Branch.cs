using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyLibrary.Models
{
    public class Branch
    {
        public int BranchID { get; set; }

        [Display(Name = "Branch Name")]
        public string BranchName { get; set; }
        public string Address { get; set; }
    }
}