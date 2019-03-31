using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HnC.Repository.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Key]
        public int UserId { get; set; }
        [Required]
        public List<OrderItem> OrderItems { get; set; }
    }
}
