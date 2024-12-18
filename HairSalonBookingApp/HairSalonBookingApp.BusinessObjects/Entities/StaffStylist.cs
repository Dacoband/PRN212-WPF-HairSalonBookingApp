﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonBookingApp.BusinessObjects.Entities
{
    public class StaffStylist : BaseEntity
    {
        public StaffStylist() : base() { }
        [Key]
        [Column("StaffStylistId")]
        public override Guid Id { get; set; }
        //FK from Branch
        public Guid BranchID { get; set; }
        //FK from Account
        public Guid AccountId { get; set; }
        public string StaffStylistName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string AvatarImage { get; set; } = string.Empty;

        [ForeignKey("BranchID")]
        public virtual Branch Branch { get; set; } = null!;

        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; } = null!;
    }
}
