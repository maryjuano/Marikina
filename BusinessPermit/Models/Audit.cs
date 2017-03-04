using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessPermit.Models
{
    public class Audit
    {
        [Key]
        public int Id { get; set; }
        public string Entity { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}