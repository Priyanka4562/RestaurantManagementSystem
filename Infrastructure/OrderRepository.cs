using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Infrastructure{
    public class OrderRepository : ICRUDRepository<Order,int>
    {
        RestaurantManagementSystemDBContext _db;

        public OrderRepository(RestaurantManagementSystemDBContext db)
        
        {
            _db = db;
        }

        public IEnumerable<Order> GetAll()
        {
            return _db.Order.ToList();
        }
        public Order GetDetails(int id)
        {

            return _db.Order.FirstOrDefault(c=>c.ID==id);
        }
        public void Create(Order item)
        {
            _db.Order.Add(item);
            _db.SaveChanges();
        }
        public void Delete(int id)
        {
            var obj = _db.Order.FirstOrDefault(c=>c.ID==id);
                if(obj == null)
                return;
            _db.Order.Remove(obj);
            _db.SaveChanges();
        }
        public void Update(Order item)
        {
            var obj = _db.Order.Find(item.ID);
                if(obj==null)
                    return;
                obj.ID=item.ID;
                obj.OrderDate=item.OrderDate;
                obj.CustomerId=item.CustomerId;
               
                _db.Entry(obj).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
                _db.SaveChanges();

        }
    }
}