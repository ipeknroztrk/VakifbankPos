using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VakifbankPos.DAL.Entities
{
    public class PosReceiver
    {
        [Key]
        public int PosReceiverId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Ad 100 karakterden uzun olamaz.")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Soyad 100 karakterden uzun olamaz.")]
        public string Surname { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi girin.")]
        public string Email { get; set; }

        [Required]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası girin.")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Sicil No 20 karakterden uzun olamaz.")]
        public string IdentificationNumber { get; set; }


        public string? ImageUrl { get; set; }

        public virtual ICollection<PosAction> PosActions { get; set; }

    }
}
