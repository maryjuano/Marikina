using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessPermit.Models
{
    public class BuildingPermit
    {
        [Key]
        public int BuildingPermitId { get; set; }
        public BuildingTypePermit BuildingTypePermit { get; set; }
        public string ApplicationNumber { get; set; }
        public string AreaNumber { get; set; }
        public string Owner { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string TIN { get; set; }
        public string FormOfOwnerShip { get; set; }
        public string OwnerStreetNumber { get; set; }
        public string OwnerStreet { get; set; }
        public string OwnerBarangay { get; set; }
        public string OwnerCity { get; set; }
        public int OwnerZipCode { get; set; }
        public string TelephoneNumber { get; set; }
        public string LocationLotNumber { get; set; }
        public string LocationBlockNumber { get; set; }
        public string LocationTCTNumber { get; set; }
        public string LocationTaxDescriptionNumber { get; set; }
        public string LocationStreet { get; set; }
        public string LocationBarangay { get; set; }
        public string LocationCity { get; set; }
        public ScopeOfWork ScopeOfWork { get; set; }
        public string ScopeOfWorkOther { get; set; }
        public BuildingUse BuildingUse { get; set; }
        public string BuildingUseOther { get; set; }
        public string OccupancyClassified { get; set; }
        public int NumberOfUnits { get; set; }
        public double TotalFloorArea { get; set; }
        public float TotalEstimatedCost { get; set; }
        public DateTime ProposedConstructionDate { get; set; }
        public DateTime ExpectedCompletionDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public byte[] Attachment { get; set; }
        public string Status { get; set; }
        public int LocationalId { get; set; }
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
        NewConstruction = 1,
        Erection = 2,
        Addition = 3,
        Aleration = 4,
        Renovation = 5,
        Conversion = 6,
        Repair = 7,
        Moving = 8,
        Raising = 9,
        AccessoryBuilding = 10,
        Others = 0
    }

    public enum BuildingUse
    {
        ResidentialDwelling = 1,
        ResidentialHotel = 2,
        Educational = 3,
        Institutional = 4,
        Business = 5,
        Industrial = 6,
        IndustrialStorage = 7,
        AssemblyOccupantLess1000 = 8,
        AssemblyOccupantMore1000 = 9,
        Agricultural = 10,
        Others = 0
    }
}