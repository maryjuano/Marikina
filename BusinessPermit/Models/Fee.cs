using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessPermit.Models
{
    public class Fee
    {
        public int FeeId { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int ApplicationTypeId { get; set; }
        public virtual ApplicationType ApplicationType { get; set; }
    }
}