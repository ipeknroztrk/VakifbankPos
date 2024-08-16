using System;
using System.ComponentModel.DataAnnotations;

namespace VakifbankPos.DAL.Entities
{
	public class PosInventory
	{
        [Key]
        public int PosId { get; set; }
        public string PosMember { get; set; }//pos cihazının üyesi
        public string Terminal { get; set; }
        public string SerialNumber { get; set; }
        public string LastIssuedTo { get; set; }// son olarak kime verildigi
        public DateTime? IssueDate { get; set; }
        public string Environment { get; set; }//ortam
        public string Vendor { get; set; }//tedarikçi firma
        public string Model { get; set; }
        public string OwnerBank { get; set; }//sahip banka
        public string PosType { get; set; }
        public bool? Status { get; set; }
        public bool IsDefective { get; set; }




        public virtual ICollection<PosAction> PosActions { get; set; }
    }
}

