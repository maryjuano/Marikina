using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessPermit.Models
{
    public class ApplicationForms
    {
        [Key]
        public int ApplicationId { get; set; }       
        public int ApplicationTypeId { get; set; }
        public ApplicationType ApplicationType { get; set; }
        public float TotalPayment { get; set; }
        public byte[] Requirements { get; set; }
        public string Status { get; set; }
    }   
}