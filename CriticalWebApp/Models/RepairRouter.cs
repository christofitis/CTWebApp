using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CriticalWebApp.Models
{
    public class RepairRouter //TODO: add "[Display(Name = "Customer First Name")]" to all fields
    {

        //contact
        [Display(Name = "RMA#")]
        public int Id { get; set; }
        [Display(Name = "Contact Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Column(TypeName = "date")]
        public DateTime ContactDate { get; set; }
        [Display(Name = "Contacted by Phone")]
        [Required]
        public bool ContactedByPhone { get; set; }
        [Display(Name = "Contacted by E-Mail")]
        public bool ContactedByEmail { get; set; }
        [Display(Name = "Correspondent")]
        [Required]
        public string TalkedTo { get; set; }
        [Display(Name = "C.O.D. Product")]
        public bool isCODProduct { get; set; }
        [Display(Name = "C.O.D. Money")]
        public bool IsCodMoney { get; set; }
        [Display(Name = "Current In Quickbooks")]
        public bool CurrentInQuickbooks { get; set; }
        [Display(Name = "First Name / Company")]
        [Required]
        public string CustomerFirstName { get; set; }
        [Display(Name = "Customer Last Name")]
        public string CustomerLastName { get; set; }
        [Display(Name = "Shop Name")]
        public string ShopName { get; set; }
        [Display(Name = "Phone Number")]
        [Required]
        public string Phone { get; set; }
        [Display(Name = "E-Mail")]
        [Required]
        public string Email { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        [DataType(DataType.Text)]
        public int? ZipCode { get; set; }
        [Display(Name = "Product in Quickbooks")]
        public bool ProdInQB { get; set; }
        [Display(Name = "Date of Purchase")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Column(TypeName = "date")]
        public DateTime? DateOfPurchase { get; set; }
        [Display(Name = "Purchased From")]
        public string PlaceOfPurchase { get; set; }
        [Display(Name = "Covered Under Warranty")]
        public bool CoveredUnderWarranty { get; set; }
        [Display(Name = "Product Model")]
        [Required]
        public string ProductModel { get; set; }

        //public string ProductGen { get; set; }
        [Display(Name = "Product Serial Number")]
        public string ProductSerialNumber { get; set; }
        //public bool DidSendPowerAdaptor { get; set; }
        [Display(Name = "Warranty Repair")]
        public bool IsWarrentyRepair { get; set; }
        [Display(Name = "Replace / Repackage")]
        public bool IsReplaceRepackage { get; set; }
        [Display(Name = "Referbish Package")]
        public bool IsReferbishPkg { get; set; }
        //public bool IsPaidRepair { get; set; }
        [Display(Name = "Amount Paid for Repair")]
        [DataType(DataType.Currency)]
        public decimal? PaidRepairAmount { get; set; }
        [Display(Name = "Return Label")]
        public string ReturnLabel { get; set; }
        //public bool IsLoggedInQb { get; set; } //for the router "return notes and repair component done in QB date: initial
        [Display(Name = "Shipment Type")]
        public string ShipType { get; set; }

        //receive
        [Display(Name = "Date Received")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Column(TypeName = "date")]
        public DateTime? DateReceived { get; set; }
        [Display(Name = "Received By")]
        public string RMAReceivedBy { get; set; }
        [Display(Name = "Did Received Product")]
        public bool ProductReceived { get; set; } //checkbox that will show that stated product and serial number was received
        //public string ReceivedModel { get; set; }
        //public string ReceivedGen { get; set; }
        //public string ReceivedSerialNumber { get; set; }
        [Display(Name = "Other Received")]
        public string OtherReceived { get; set; }  //list of things received by customer

        //public bool ReceivedAdaptor { get; set; }
        //public bool ReceivedCord { get; set; }
        //public bool ReceivedMount { get; set; }    ////made into a list ienumberable OtherReceived
        //public bool ReceivedBox { get; set; }
        //public string ReceivedOther { get; set; }

        //repair
        [Display(Name = "Is within the USA")]
        public bool IsWithinTheUSA { get; set; }
        [Display(Name = "Customer Complaint")]
        public string CustomerComplaint { get; set; }
        [Display(Name = "Special Instructions")]
        public string SpecialInstructions { get; set; }
        [Display(Name = "Repaired")]
        public bool WasRepaired { get; set; }
        [Display(Name = "Replaced")]
        public bool WasReplaced { get; set; }
        [Display(Name = "Repair Notes")]
        public string RepairNotes { get; set; }
        [Display(Name = "Repair Done By")]
        public string RepairDoneBy { get; set; }
        [Display(Name = "Repair Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Column(TypeName = "date")]
        public DateTime? RepairDate { get; set; }
        [Display(Name = "Serial# Sent Out")]
        public string OutSerialNumber { get; set; }
        [Display(Name = "First Tester")]
        public string FirstTester { get; set; }
        [Display(Name = "Second Tester")]
        public string SecondTester { get; set; }
    }
}