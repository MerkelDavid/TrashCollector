using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleID { get; set; }

        public string Customer { get; set; }
        public string Day { get; set; }

        public string Frequency { get; set; }

        public bool VacationMode { get; set; }

    }
}