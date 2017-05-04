using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessPermit.Models
{
    public class Payment
    {
        public int Id { get; set; }       
        [Required(ErrorMessage = "Payment Reference Number is required")]
        public string ReferenceNumber { get; set; }
        [Required(ErrorMessage = "Official Receipt Number is required")]
        public string OfficialReceiptNumber { get; set; }
        [Required(ErrorMessage = "Application Type is required")]
        public PaymentApplicationType? ApplicationType { get; set; }
        public float TotalPayment { get; set; }
        public string Status { get; set; }
    }

    public enum PaymentApplicationType
    {
        Zoning = 1,
        Locational = 2,
        Business = 3,
        Building = 4
    }
}