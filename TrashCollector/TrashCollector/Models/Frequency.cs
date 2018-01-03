using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrashCollector.Models
{
    public class Frequency
    {
        [Key]
        public int FrequencyID { set; get; }
        public string frequency { set; get; }
    }
}