namespace RestaurantManagementSystem.Models
{
    public class OrderDetails
    {
        public int Id {get; set; }
        public int OrderId {get; set; }
        public int ItemId {get; set; }
        public int Price {get; set; }
        public int Quantity {get; set; }
    }
}