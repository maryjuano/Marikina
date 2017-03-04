using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessPermit.Models
{
    public class ApplicationType
    {
        public ApplicationType() {
            Fees = new List<Fee>();
        }
        [Key]
        public int ApplicationTypeId { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Fee> Fees { get; set; }
    }
}