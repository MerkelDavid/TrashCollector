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

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

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