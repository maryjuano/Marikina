using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessPermit.Models
{
    public class BusinessPermit
    {
        [Key]
        public int Id { get; set; }
        public bool IsNew { get; set; }
        public int BusinessAccountNumber { get; set; }
        public DateTime DateApplied { get; set; }
        public string BusinessName { get; set; }
        public string OwnerName { get; set; }
        public string BusinessAddress { get; set; }
        public string BusinessNature { get; set; }
        public int DeliveryVehicles { get; set; }
        public double TotalAreaBusiness { get; set; }
        public int ContactNumber { get; set; }
        public int TotalEmployee { get; set; }
        public string RentedOwnerName { get; set; }

        public float MonthlyRental { get; set; }

        public float JanGrossReceipt { get; set; }

        public float FebGrossReceipt { get; set; }
        public float MarGrossReceipt { get; set; }
        public float AprGrossReceipt { get; set; }
        public float MayGrossReceipt { get; set; }
        public float JunGrossReceipt { get; set; }
        public float JulGrossReceipt { get; set; }
        public float AugGrossReceipt { get; set; }
        public float SepGrossReceipt { get; set; }

        public float OctGrossReceipt { get; set; }
        public float NovGrossReceipt { get; set; }
        public float DecGrossReceipt { get; set; }
        public float TotalGrossReceipt { get; set; }
        public float CapitalInvestment { get; set; }
        public string DateStartedRemarks { get; set; }
        public string CapitalInvestmentRemarks { get; set; }
        public string AreaRemarks { get; set; }
        public float GrossSalesPerDay { get; set; }
        public float GrossSalesPerYear { get; set; }
        public string PreviousBasisLicenseTax { get; set; }
        public string CurrentBasisLicenseTax { get; set; }
        public float AssessedAmount { get; set; }
        public string Status { get; set; }
        [Required(ErrorMessage = "Attachments are required.")]
        public byte[] Attachments { get; set; }
        public string PaymentReference { get; set; }
        public float TotalPayment { get; set; }
        public string ZoningClearanceReferenceNumber { get; set; }
        public int ZoningClearanceId { get; set; }
        public ZoningClearance ZoningClearance { get; set; }
    }
}