using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HnC.Repository.Models
{
    public class OrderItem
    {
        [Required]
        public int ItemId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
