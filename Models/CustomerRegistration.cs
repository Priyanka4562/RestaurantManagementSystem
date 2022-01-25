namespace RestaurantManagementSystem.Models
{
    public class CustomerRegistration
    {
        public int Id {get; set; }
        public string  Name {get; set; }
        public long Phonenumber {get; set; }
        public string Email {get; set;}
        public string Password {get; set;}
        public int RoleID {get; set;}

    }
}