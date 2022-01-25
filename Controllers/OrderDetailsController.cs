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
    public class OrderDetailsController : ControllerBase
    {
        ICRUDRepository<OrderDetails, int> _repository;
        public OrderDetailsController(ICRUDRepository<OrderDetails,int> repository) 
            =>_repository = repository;
        
        
        public ActionResult<IEnumerable<OrderDetails>> Get()
        {
           
            var items = _repository.GetAll();
            return items.ToList();
        }
        [HttpGet("{id}")]

        public ActionResult<OrderDetails> GetDetails(int id)
        {
            var item =_repository.GetDetails(id);
            if(item == null)
                return NotFound();
            return item;

        }

        [HttpPost("addnew")]

        public ActionResult<OrderDetails> Create(OrderDetails rol)
        {
            if(rol == null)
            {
                return BadRequest();
            }

            _repository.Create(rol);
            return rol;
        }

        [HttpPut("update/{id}")]
        public ActionResult<OrderDetails> Update(int id,OrderDetails rol)
        {
            if(rol == null)
                return BadRequest();
            _repository.Update(rol);
            return rol;
        }
        [HttpDelete("remove/{id}")]
        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            return Ok();
        }
    
    }
}