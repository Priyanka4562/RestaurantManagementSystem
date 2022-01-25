using System.ComponentModel.DataAnnotations;
namespace RestaurantManagementSystem.Models
{
    public class Roles
    {
        [Key]
        public int ID {get; set; }
        public string RoleName {get; set; }
    }
}