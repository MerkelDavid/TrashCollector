using System;
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

    public class AddressDbContext :DbContext
    {
        public DbSet<Adress> Address { get; set; }
    }

    public class ScheduleDbContext : DbContext
    {
        public DbSet<Schedule> Schedule { get; set; }
    }
}