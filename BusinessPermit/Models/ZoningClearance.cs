using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessPermit.Models
{
    public class ZoningClearance
    {
        public int ZoningClearanceId { get; set; }
        public string ApplicationNumber { get; set; }
        public DateTime DateApplied { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string BusinessName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string OwnerName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string BusinessAddress { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string BusinessNature { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string ContactNumber { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string MainOffice { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int TotalFloorArea { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int FloorAreaBusiness { get; set; }
        public string PaymentReference { get; set; }
        public float TotalPayment { get; set; }
        public string Status { get; set; }
        [Required(ErrorMessage = "Attachments are required.")]
        public byte[] Attachments { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string EmailAddress { get; set; }
        public List<Fee> Fees { get; set; }
    }

   



   
}

