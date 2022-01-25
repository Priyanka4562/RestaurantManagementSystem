using  Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Infrastructure;
using RestaurantManagementSystem.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddScoped<ICRUDRepository<Restaurant, int>, RestaurantRepository>();
// builder.Services.AddScoped<ICRUDRepository<Roles, int>, RolesRepository>();
// builder.Services.AddScoped<ICRUDRepository<CustomerRegistration, int>, CustomerRegistrationRepository>();
// builder.Services.AddScoped<ICRUDRepository<Category, int>, CategoryRepository>();
// builder.Services.AddScoped<ICRUDRepository<Items, int>, ItemsRepository>();
// builder.Services.AddScoped<ICRUDRepository<Order, int>, OrderRepository>();
// builder.Services.AddScoped<ICRUDRepository<OrderDetails, int>, OrderDetailsRepository>();


builder.Services.AddDbContext<RestaurantManagementSystem.Infrastructure.RestaurantManagementSystemDBContext>
(
    options=>
        options.UseSqlServer
        (
            connectionString: "server=(local);database=RestaurantDB;integrated security=sspi"
        )
);
builder.Services.AddScoped<ICRUDRepository<Restaurant, int>, RestaurantRepository>();
builder.Services.AddScoped<ICRUDRepository<Roles, int>, RolesRepository>();
builder.Services.AddScoped<ICRUDRepository<CustomerRegistration, int>, CustomerRegistrationRepository>();
builder.Services.AddScoped<ICRUDRepository<Category, int>, CategoryRepository>();
builder.Services.AddScoped<ICRUDRepository<Items, int>, ItemsRepository>();
builder.Services.AddScoped<ICRUDRepository<Order, int>, OrderRepository>();
builder.Services.AddScoped<ICRUDRepository<OrderDetails, int>, OrderDetailsRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();