namespace RestaurantManagementSystem.Models
{
    public class Order
    {
        public int ID {get; set; }
        public DateTime OrderDate {get; set; }
        public int CustomerId {get; set; }

    }
}