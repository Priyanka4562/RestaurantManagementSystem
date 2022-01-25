using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Infrastructure{
    public class OrderDetailsRepository : ICRUDRepository<OrderDetails,int>
    {
        RestaurantManagementSystemDBContext _db;

        public OrderDetailsRepository(RestaurantManagementSystemDBContext db)
        
        {
            _db = db;
        }

        public IEnumerable<OrderDetails> GetAll()
        {
            return _db.OrderDetails.ToList();
        }
        public OrderDetails GetDetails(int id)
        {

            return _db.OrderDetails.FirstOrDefault(c=>c.Id==id);
        }
        public void Create(OrderDetails item)
        {
            _db.OrderDetails.Add(item);
            _db.SaveChanges();
        }
        public void Delete(int id)
        {
            var obj = _db.OrderDetails.FirstOrDefault(c=>c.Id==id);
                if(obj == null)
                return;
            _db.OrderDetails.Remove(obj);
            _db.SaveChanges();
        }
        public void Update(OrderDetails item)
        {
            var obj = _db.OrderDetails.Find(item.Id);
                if(obj==null)
                    return;
                obj.Id=item.Id;
                obj.ItemId=item.ItemId;
                obj.Price=item.Price;
                obj.Quantity=item.Quantity;
                obj.OrderId=item.OrderId;
                _db.Entry(obj).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
                _db.SaveChanges();

        }
    }
}