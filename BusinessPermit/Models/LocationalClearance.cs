using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessPermit.Models
{
    public class LocationalClearance
    {
        public int LocationalClearanceId { get; set; }
        public string ApplicationNumber { get; set; }
        public DateTime DateApplied { get; set; }       
        public string LCPermitNumber { get; set; }        
        public DateTime DateIssued { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Project { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Location { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Firm { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public double FloorArea { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public double LandArea { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int UsableOpenSpace { get; set; }     
        public string TCTNumber { get; set; }
        public float TotalPayment { get; set; }
        public string PaymentReference { get; set; }
        public string Status { get; set; }
        [Required(ErrorMessage = "Attachments are required.")]
        public byte[] Attachments { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string EmailAddress { get; set; }
        public List<Fee> Fees { get; set; }
    }
}