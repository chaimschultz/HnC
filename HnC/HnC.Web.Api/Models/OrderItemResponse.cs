using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HnC.Web.Api.Models
{
    public class OrderItemResponse
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
    }
}
