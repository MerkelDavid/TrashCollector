using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrashCollector.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        public int CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int SecurityCode { get; set; }
    }
}