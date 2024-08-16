using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VakifbankPos.DAL.Entities
{
    public class PosAction
    {
        [Key]
        public int PosActionId { get; set; }

        [Required]
        public int PosId { get; set; }


        [Required]
        public int PosReceiverId { get; set; } 

        [Required]
        [StringLength(100, ErrorMessage = "Verilen kişi 100 karakterden uzun olamaz.")]
        public string IssuedTo { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public bool Returned { get; set; }

        [ForeignKey("PosId")]
        public virtual PosInventory PosInventory { get; set; }

        [ForeignKey("PosReceiverId")]
        public virtual PosReceiver PosReceiver { get; set; }
    }
}    