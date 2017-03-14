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
        public int ContactNumber { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string MainOffice { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int TotalFloorArea { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int FloorAreaBusiness { get; set; }
        public string Status { get; set; }
        public byte[] Attachments { get; set; }
    }

    public class LocationalClearance
    {
        public int LocationalClearanceId { get; set; }
        public string ApplicationNumber { get; set; }
        public DateTime DateApplied { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string LCPermitNumber { get; set; }
        [Required(ErrorMessage = "This field is required.")]
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
        [Required(ErrorMessage = "This field is required.")]
        public string TCTNumber { get; set; }
        public string Status { get; set; }
        public byte[] Attachments { get; set; }
    }

    public class BusinessPermit
    {       
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
    }
}

