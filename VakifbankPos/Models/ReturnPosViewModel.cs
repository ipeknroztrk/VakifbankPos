using System.ComponentModel.DataAnnotations;

namespace VakifbankPos.Models
{
    public class ReturnPosViewModel
    {
        public int PosActionId { get; set; }
        public int PosId { get; set; }
        public DateTime IssueDate { get; set; }

        [Required(ErrorMessage = "Geri getirme tarihi gereklidir.")]
        public DateTime ReturnDate { get; set; }
    }

}
