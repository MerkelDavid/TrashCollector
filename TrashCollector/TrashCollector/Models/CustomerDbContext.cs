﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TrashCollector.Models
{
    public class CustomerDbContext :DbContext
    {
        public DbSet<Customer> Customer { get; set; }
    }
}