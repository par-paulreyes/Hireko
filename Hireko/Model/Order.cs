namespace Hireko.Model
{
     internal class Order
    {
        public int OrderId { get; set; }

        public int SellerUserId { get; set; }

        public int BuyerUserId { get; set; }

        public int ServiceId { get; set; }

        public string OrderStatus { get; set; }

    }

    internal static class CurrentOrder
    {
    }
}