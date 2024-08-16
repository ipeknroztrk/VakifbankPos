using System;
using System.ComponentModel.DataAnnotations;

namespace VakifbankPos.Models
{
    public class PosActionViewModel
    {
        [Required]
        public int PosId { get; set; }

        [Required]
        public int PosReceiverId { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }

        public bool Returned { get; set; }
       
    }
}
