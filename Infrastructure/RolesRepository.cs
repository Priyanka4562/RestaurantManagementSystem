using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Infrastructure{
    public class RolesRepository : ICRUDRepository<Roles,int>
    {
        RestaurantManagementSystemDBContext _db;

        public RolesRepository(RestaurantManagementSystemDBContext db)
        
        {
            _db = db;
        }

        public IEnumerable<Roles> GetAll()
        {
            return _db.Roles.ToList();
        }
        public Roles GetDetails(int id)
        {

            return _db.Roles.FirstOrDefault(c=>c.ID==id);
        }
        public void Create(Roles item)
        {
            _db.Roles.Add(item);
            _db.SaveChanges();
        }
        public void Delete(int id)
        {
            var obj = _db.Roles.FirstOrDefault(c=>c.ID==id);
                if(obj == null)
                return;
            _db.Roles.Remove(obj);
            _db.SaveChanges();
        }
        public void Update(Roles item)
        {
            var obj = _db.Roles.Find(item.ID);
                if(obj==null)
                    return;
                obj.ID=item.ID;
                obj.RoleName=item.RoleName;
                
                
                _db.Entry(obj).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
                _db.SaveChanges();

        }
    }
}