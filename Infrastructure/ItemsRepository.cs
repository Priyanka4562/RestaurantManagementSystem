using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Infrastructure{
    public class ItemsRepository : ICRUDRepository<Items,int>
    {
        RestaurantManagementSystemDBContext _db;

        public ItemsRepository(RestaurantManagementSystemDBContext db)
        
        {
            _db = db;
        }

        public IEnumerable<Items> GetAll()
        {
            return _db.Items.ToList();
        }
        public Items GetDetails(int id)
        {
            return _db.Items.FirstOrDefault(c=>c.ID==id);
        }
        public void Create(Items item)
        {
            _db.Items.Add(item);
            _db.SaveChanges();
        }
        public void Delete(int id)
        {
            var obj = _db.Items.FirstOrDefault(c=>c.ID==id);
                if(obj == null)
                return;
            _db.Items.Remove(obj);
            _db.SaveChanges();
        }
        public void Update(Items item)
        {
            var obj = _db.Items.Find(item.ID);
                if(obj==null)
                    return;
                obj.ID=item.ID;
                obj.Name=item.Name;
                obj.CategoryId=item.CategoryId;
                obj.ItemPrice=item.ItemPrice;
                
                
                
                _db.Entry(obj).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
                _db.SaveChanges();

        }
    }
}