using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Infrastructure{
    public class RestaurantRepository : ICRUDRepository<Restaurant,int>
    {
        RestaurantManagementSystemDBContext _db;

        public RestaurantRepository(RestaurantManagementSystemDBContext db)
        
        {
            _db = db;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _db.Restaurant.ToList();
        }
        public Restaurant GetDetails(int id)
        {
            return _db.Restaurant.FirstOrDefault(c=>c.ID==id);
        }
        public void Create(Restaurant item)
        {
            _db.Restaurant.Add(item);
            _db.SaveChanges();
        }
        public void Delete(int id)
        {
            var obj = _db.Restaurant.FirstOrDefault(c=>c.ID==id);
                if(obj == null)
                return;
            _db.Restaurant.Remove(obj);
            _db.SaveChanges();
        }
        public void Update(Restaurant item)
        {
            var obj = _db.Restaurant.Find(item.ID);
                if(obj==null)
                    return;
                obj.ID=item.ID;
                obj.Name=item.Name;
                obj.Location=item.Location;
                obj.Phonenumber=item.Phonenumber;
                
                _db.Entry(obj).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
                _db.SaveChanges();

        }
    }
}