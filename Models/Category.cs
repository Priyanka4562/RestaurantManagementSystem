namespace RestaurantManagementSystem.Models
{
    public class Category
    {
        public int Id {get; set; }
        public string Name {get; set; }
        public bool IsVeg {get; set; }
        public bool IsNonVeg {get; set;}

    }
}