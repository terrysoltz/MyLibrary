﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyLibrary.Models
{
    public class Publisher
    {
        [Key]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}