using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HnC.Repository.Models
{
    public class Basket
    {
        [Key]
        public int BasketId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ItemId { get; set; }
        [Required]
        public int Quantity { get; set; }

    }
}
