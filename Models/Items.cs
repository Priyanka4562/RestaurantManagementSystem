using System.ComponentModel.DataAnnotations;
namespace RestaurantManagementSystem.Models
{
    public class Items
    {
        [Key]
        public int ID {get; set; }
        public string Name {get; set; }
        public int CategoryId {get; set; }
        public int ItemPrice {get; set;}

    }
}