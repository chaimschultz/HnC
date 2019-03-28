namespace HnC.Web.Api.Models
{
    public class BasketItemPostRequest
    {
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
