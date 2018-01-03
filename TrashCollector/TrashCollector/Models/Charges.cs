using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrashCollector.Models
{
    public class Charges
    {
        [Key]
        public int ChargeID { get; set; }
        public int CustomerID { get;set;}
        public DateTime DateBilled { get; set; }
        public bool Paid { get; set; }
        public double Amount { get; set; }
    }
}