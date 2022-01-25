using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.Models;
using RestaurantManagementSystem.Infrastructure;


namespace RestaurantManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerRegistrationController : ControllerBase
    {
        ICRUDRepository<CustomerRegistration, int> _repository;
        public CustomerRegistrationController(ICRUDRepository<CustomerRegistration,int> repository) 
            =>_repository = repository;
        
        
        public ActionResult<IEnumerable<CustomerRegistration>> Get()
        {
           
            var CustomerRegistration = _repository.GetAll();
            return CustomerRegistration.ToList();
        }
        [HttpGet("{id}")]

        public ActionResult<CustomerRegistration> GetDetails(int id)
        {
            var item =_repository.GetDetails(id);
            if(item == null)
                return NotFound();
            return item;

        }

        [HttpPost("addnew")]

        public ActionResult<CustomerRegistration> Create(CustomerRegistration cust)
        {
            if(cust == null)
            {
                return BadRequest();
            }

            _repository.Create(cust);
            return cust;
        }

        [HttpPut("update/{id}")]
        public ActionResult<CustomerRegistration> Update(int id,CustomerRegistration cust)
        {
            if(cust == null)
                return BadRequest();
            _repository.Update(cust);
            return cust;
        }
        [HttpDelete("remove/{id}")]
        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            return Ok();
        }
    }
    
}