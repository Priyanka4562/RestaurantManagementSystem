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
    public class RestaurantController : ControllerBase
    {
        ICRUDRepository<Restaurant, int> _repository;
        public RestaurantController(ICRUDRepository<Restaurant,int> repository) 
            =>_repository = repository;
        
        
        public ActionResult<IEnumerable<Restaurant>> Get()
        {
           
            var items = _repository.GetAll();
            return items.ToList();
        }
        [HttpGet("{id}")]

        public ActionResult<Restaurant> GetDetails(int id)
        {
            var item =_repository.GetDetails(id);
            if(item == null)
                return NotFound();
            return item;

        }

        [HttpPost("addnew")]

        public ActionResult<Restaurant> Create(Restaurant res)
        {
            if(res == null)
            {
                return BadRequest();
            }

            _repository.Create(res);
            return res;
        }

        [HttpPut("update/{id}")]
        public ActionResult<Restaurant> Update(int id,Restaurant res)
        {
            if(res == null)
                return BadRequest();
            _repository.Update(res);
            return res;
        }
        [HttpDelete("remove/{id}")]
        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            return Ok();
        }
    }
}