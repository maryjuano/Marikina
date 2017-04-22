using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessPermit.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime DateApplied { get; set; }
        public DateTime DatePaid { get; set; }
        public string Status { get; set; }
    }
}