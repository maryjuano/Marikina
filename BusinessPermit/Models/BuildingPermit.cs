using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessPermit.Models
{
    public class BuildingPermit
    {
        [Key]
        public int BuildingPermitId { get; set; }
        [Required(ErrorMessage = "Building Type is required.")]
        public BuildingTypePermit BuildingTypePermit { get; set; }
        public string ApplicationNumber { get; set; }
        [Required(ErrorMessage = "Area Number is required.")]
        public string AreaNumber { get; set; }
        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        [Required(ErrorMessage = "TIN is required.")]
        public string TIN { get; set; }
        public string FormOfOwnerShip { get; set; }
        public string OwnerStreetNumber { get; set; }
        public string OwnerStreet { get; set; }
        public string OwnerBarangay { get; set; }
        public string OwnerCity { get; set; }
        public int OwnerZipCode { get; set; }
        [Required(ErrorMessage = "Telephone Number is required.")]
        public string TelephoneNumber { get; set; }
        [Required(ErrorMessage = "Lot Number is required.")]
        public string LocationLotNumber { get; set; }
        [Required(ErrorMessage = "Block Number is required.")]
        public string LocationBlockNumber { get; set; }
        [Required(ErrorMessage = "TCT Number is required.")]
        public string LocationTCTNumber { get; set; }

        public string LocationTaxDescriptionNumber { get; set; }
        [Required(ErrorMessage = "Street is required.")]
        public string LocationStreet { get; set; }
        [Required(ErrorMessage = "Barangay is required.")]
        public string LocationBarangay { get; set; }
        [Required(ErrorMessage = "City is required.")]
        public string LocationCity { get; set; }
        [Required(ErrorMessage = "Scope of Work is required.")]
        public ScopeOfWork ScopeOfWork { get; set; }
        public string ScopeOfWorkOther { get; set; }
        [Required(ErrorMessage = "Building Use is required.")]
        public BuildingUse BuildingUse { get; set; }
        public string BuildingUseOther { get; set; }
        public string OccupancyClassified { get; set; }
        public int NumberOfUnits { get; set; }
        public double TotalFloorArea { get; set; }
        public float TotalEstimatedCost { get; set; }
        [Required(ErrorMessage = "Proposed Construction Date is required.")]
        public DateTime ProposedConstructionDate { get; set; }
        [Required(ErrorMessage = "Expected Completion Date is required.")]
        public DateTime ExpectedCompletionDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public byte[] Attachment { get; set; }
        public string Status { get; set; }
        public string PaymentReference { get; set; }
        public float TotalPayment { get; set; }
        [Required(ErrorMessage = "LC Reference Number is required.")]
        public string LocationaClearanceReference { get; set; }
        public int LocationalClearanceId { get; set; }
        public LocationalClearance LocationalClearance { get; set; }
    }

    public enum BuildingTypePermit
    {
        New = 1,
        Renew = 2,
        Amendatory = 3
    }
    public enum ScopeOfWork
    {
        [Description("Others (Specify)")]
        Others = 0,
        [Description("New Construction")]
        NewConstruction = 1,
        Erection = 2,
        Addition = 3,
        Aleration = 4,
        Renovation = 5,
        Conversion = 6,
        Repair = 7,
        Moving = 8,
        Raising = 9,
        [Description("Accessory Building/Structure")]
        AccessoryBuilding = 10,


    }

    public enum BuildingUse
    {
        [Description("Others (Specify)")]
        Others = 0,
        [Description("Group A : Residential, Dwellings")]
        ResidentialDwelling = 1,
        [Description("Group B : Residential Hotel, Apartment")]
        ResidentialHotel = 2,
        [Description("Group C : Educational, Recreational")]
        Educational = 3,
        [Description("Group D : Institutional")]
        Institutional = 4,
        [Description("Group E : Business and Mercantile")]
        Business = 5,
        [Description("Group F : Industrial")]
        Industrial = 6,
        [Description("GROUP G : Industrial Storage and Hazardous")]
        IndustrialStorage = 7,
        [Description("GROUP H : Recreational, Assembly Occupant Load Less Than 1000 ")]
        AssemblyOccupantLess1000 = 8,
        [Description("GROUP I : Recreational, Assembly Occupant Load 1000 Or More ")]
        AssemblyOccupantMore1000 = 9,
        [Description("GROUP J : Agricultural, Accessory")]
        Agricultural = 10,

    }
}