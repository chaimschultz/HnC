namespace HnC.Web.Api.Models
{
    public class BasketItemPostResponse
    {
        public int BasketId { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
