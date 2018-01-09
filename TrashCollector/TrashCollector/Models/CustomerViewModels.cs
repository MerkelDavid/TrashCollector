using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class AddressViewModel
    {
        [Display(Name = "Address")]
        public Adress Adress { get; set; }
    }

    public class PaymentViewModel
    {
        public int PaymentID { get; set; }
        [Required]
        public int CardNumber { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
        [Required]
        public int SecurityCode { get; set; }
    }
}