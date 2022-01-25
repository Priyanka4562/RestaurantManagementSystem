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
    public class ItemsController : ControllerBase
    {
        ICRUDRepository<Items, int> _repository;
        public ItemsController(ICRUDRepository<Items,int> repository) 
            =>_repository = repository;
        
        
        public ActionResult<IEnumerable<Items>> Get()
        {
           
            var items = _repository.GetAll();
            return items.ToList();
        }
        [HttpGet("{id}")]

        public ActionResult<Items> GetDetails(int id)
        {
            var item =_repository.GetDetails(id);
            if(item == null)
                return NotFound();
            return item;

        }

        [HttpPost("addnew")]

        public ActionResult<Items> Create(Items item)
        {
            if(item == null)
            {
                return BadRequest();
            }

            _repository.Create(item);
            return item;
        }

        [HttpPut("update/{id}")]
        public ActionResult<Items> Update(int id,Items item)
        {
            if(item == null)
                return BadRequest();
            _repository.Update(item);
            return item;
        }
        [HttpDelete("remove/{id}")]
        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            return Ok();
        }
    
    }
}