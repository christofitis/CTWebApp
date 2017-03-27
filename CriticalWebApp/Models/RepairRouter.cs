using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CriticalWebApp.Models
{
    public class RepairRouter
    {

        //contact
        public int Id { get; set; }
        public DateTime ContactDate { get; set; }
        public bool ContactedByPhone { get; set; }
        public bool ContactedByEmail { get; set; }
        public string TalkedTo { get; set; }
        public bool isCODProduct { get; set; }
        public bool IsCodMoney { get; set; }
        public bool CurrentInQuickbooks { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string ShopName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public bool ProdInQB { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public string PlaceOfPurchase { get; set; }
        public bool CoveredUnderWarranty { get; set; }
        public string ProductModel { get; set; }

        public string ProductGen { get; set; }

        public string ProductSerialNumber { get; set; }
        public bool DidSendAdaptor { get; set; }
        public bool IsWarrentyRepair { get; set; }
        public bool IsReplaceRepackage { get; set; }
        public bool IsReferbishPkg { get; set; }
        public bool IsPaidRepair { get; set; }
        public decimal PaidRepairAmount { get; set; }
        public string ReturnLabel { get; set; }
        public bool IsLoggedInQb { get; set; } //for the router "return notes and repair component done in QB date: initial
        public string ShipType { get; set; }

        //receive
        public DateTime DateReceived { get; set; }
        public string RMAReceivedBy { get; set; }
        //public string ReceivedModel { get; set; }
        //public string ReceivedGen { get; set; }
        //public string ReceivedSerialNumber { get; set; }

        public List<string> OtherReceived { get; set; }  //list of things received by customer

        //public bool ReceivedAdaptor { get; set; }
        //public bool ReceivedCord { get; set; }
        //public bool ReceivedMount { get; set; }    ////made into a list ienumberable OtherReceived
        //public bool ReceivedBox { get; set; }
        //public string ReceivedOther { get; set; }

        //repair
        public bool IsWithinTheUSA { get; set; }
        public string CustomerComplaint { get; set; }
        public string SpecialInstructions { get; set; }
        public bool WasRepaired { get; set; }
        public bool WasReplaced { get; set; }
        public string RepairDoneBy { get; set; }
        public DateTime RepairDate { get; set; }
        public string OutSerialNumber { get; set; }
        public bool FirstTestDone { get; set; }
        public string FirstTester { get; set; }
        public bool SecondTestDone { get; set; }
        public string SecondTester { get; set; }
    }
}