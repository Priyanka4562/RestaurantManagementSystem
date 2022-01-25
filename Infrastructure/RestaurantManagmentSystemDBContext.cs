using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Infrastructure
{
    public class RestaurantManagementSystemDBContext : DbContext
    {
        public RestaurantManagementSystemDBContext(DbContextOptions<RestaurantManagementSystemDBContext> options) : base(options){ }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
        public DbSet<Restaurant> Restaurant {get; set;}
        public DbSet<Roles> Roles { get;  set; }
        public DbSet<OrderDetails> OrderDetails { get;  set; }
        public DbSet<Order> Order { get;  set; }
        public DbSet<Items> Items { get;  set; }
        public DbSet<Category> Category { get;  set; }
        public DbSet<CustomerRegistration> CustomerRegistration { get;  set; }
    }
}