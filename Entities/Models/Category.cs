﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Category :BaseEntity
    {
        public string? CategoryName { get; set; }

        public ICollection<Book>? Book { get; set; }
    }
}
