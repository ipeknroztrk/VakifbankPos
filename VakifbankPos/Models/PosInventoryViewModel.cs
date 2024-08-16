using System;
namespace VakifbankPos.Models
{
    public class PosInventoryViewModel
    {
        public string SerialNumber { get; set; }
        public string Model { get; set; }
        public string OwnerBank { get; set; }
        public string Terminal { get; set; }
        public string LastBorrower { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public int PosId { get; set; }
    }
}