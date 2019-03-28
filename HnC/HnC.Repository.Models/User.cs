using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HnC.Repository.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public List<Basket> BasketItems { get; set; }
    }
}
