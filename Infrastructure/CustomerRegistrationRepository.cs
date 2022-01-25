using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Infrastructure{
    public class CustomerRegistrationRepository : ICRUDRepository<CustomerRegistration,int>
    {
        RestaurantManagementSystemDBContext _db;

        public CustomerRegistrationRepository(RestaurantManagementSystemDBContext db)
        
        {
            _db = db;
        }

        public IEnumerable<CustomerRegistration> GetAll()
        {
            return _db.CustomerRegistration.ToList();
        }
        public CustomerRegistration GetDetails(int id)
        {

            return _db.CustomerRegistration.FirstOrDefault(c=>c.Id==id);
        }
        public void Create(CustomerRegistration item)
        {
            _db.CustomerRegistration.Add(item);
            _db.SaveChanges();
        }
        public void Delete(int id)
        {
            var obj = _db.CustomerRegistration.FirstOrDefault(c=>c.Id==id);
                if(obj == null)
                return;
            _db.CustomerRegistration.Remove(obj);
            _db.SaveChanges();
        }
        public void Update(CustomerRegistration item)
        {
            var obj = _db.CustomerRegistration.Find(item.Id);
                if(obj==null)
                    return;
                obj.Id=item.Id;
                obj.Name=item.Name;
                obj.Password=item.Password; 
                obj.Phonenumber=item.Phonenumber;
                obj.RoleID=item.RoleID;
                obj.Email=item.Email;
                _db.Entry(obj).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
                _db.SaveChanges();

        }
    }
}