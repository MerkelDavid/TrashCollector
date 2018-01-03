using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public int FrequencyID { get; set; }
        public Frequency Frequency { get; set; }
        public int AddressID { get; set; }
        public Adress Adress { get; set; }
        public Payment Payment { get; set; }
        public int PaymentID { get; set; }
        public Charges Charges { get; set; }
        public int ChargesID { get; set; }
    }
}