﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entityes
{
   public class Page
    { 
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Html { get; set; }
    }
}
