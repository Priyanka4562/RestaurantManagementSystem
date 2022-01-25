using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Infrastructure{
    public class CategoryRepository : ICRUDRepository<Category,int>
    {
        RestaurantManagementSystemDBContext _db;

        public CategoryRepository(RestaurantManagementSystemDBContext db)
        
        {
            _db = db;
        }

        public IEnumerable<Category> GetAll()
        {
            return _db.Category.ToList();
        }
        public Category GetDetails(int id)
        {

            return _db.Category.FirstOrDefault(c=>c.Id==id);
        }
        public void Create(Category item)
        {
            _db.Category.Add(item);
            _db.SaveChanges();
        }
        public void Delete(int id)
        {
            var obj = _db.Category.FirstOrDefault(c=>c.Id==id);
                if(obj == null)
                return;
            _db.Category.Remove(obj);
            _db.SaveChanges();
        }
        public void Update(Category item)
        {
            var obj = _db.Category.Find(item.Id);
                if(obj==null)
                    return;
                obj.Name=item.Name;
                obj.IsNonVeg=item.IsNonVeg;
                obj.IsVeg=item.IsVeg;               
                _db.Entry(obj).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
                _db.SaveChanges();

        }
    }
}