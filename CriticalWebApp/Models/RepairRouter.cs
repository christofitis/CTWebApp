﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CriticalWebApp.Models
{
    public class RepairRouter //TODO: add "[Display(Name = "Customer First Name")]" to all fields
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
        [DataType(DataType.Text)]
        public int ZipCode { get; set; }
        public bool ProdInQB { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public string PlaceOfPurchase { get; set; }
        public bool CoveredUnderWarranty { get; set; }
        public string ProductModel { get; set; }

        public string ProductGen { get; set; }

        public string ProductSerialNumber { get; set; }
        public bool DidSendPowerAdaptor { get; set; }
        public bool IsWarrentyRepair { get; set; }
        public bool IsReplaceRepackage { get; set; }
        public bool IsReferbishPkg { get; set; }
        public bool IsPaidRepair { get; set; }
        [DataType(DataType.Currency)]
        public decimal PaidRepairAmount { get; set; }
        public string ReturnLabel { get; set; }
        public bool IsLoggedInQb { get; set; } //for the router "return notes and repair component done in QB date: initial
        public string ShipType { get; set; }

        //receive
        public DateTime DateReceived { get; set; }
        public string RMAReceivedBy { get; set; }
        public bool ProductReceived { get; set; } //checkbox that will show that stated product and serial number was received
        //public string ReceivedModel { get; set; }
        //public string ReceivedGen { get; set; }
        //public string ReceivedSerialNumber { get; set; }

        public string OtherReceived { get; set; }  //list of things received by customer

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
        public string RepairNotes { get; set; }
        public string RepairDoneBy { get; set; }
        public DateTime RepairDate { get; set; }
        public string OutSerialNumber { get; set; }
        public string FirstTester { get; set; }
        public string SecondTester { get; set; }
    }
}