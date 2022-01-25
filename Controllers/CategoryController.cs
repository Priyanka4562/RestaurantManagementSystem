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
    public class CategoryController : ControllerBase
    {
        ICRUDRepository<Category, int> _repository;
        public CategoryController(ICRUDRepository<Category,int> repository) 
            =>_repository = repository;
        
        
        public ActionResult<IEnumerable<Category>> Get()
        {
           
            var items = _repository.GetAll();
            return items.ToList();
        }
        [HttpGet("{id}")]

        public ActionResult<Category> GetDetails(int id)
        {
            var item =_repository.GetDetails(id);
            if(item == null)
                return NotFound();
            return item;

        }

        [HttpPost("addnew")]

        public ActionResult<Category> Create(Category cat)
        {
            if(cat == null)
            {
                return BadRequest();
            }

            _repository.Create(cat);
            return cat;
        }

        [HttpPut("update/{id}")]
        public ActionResult<Category> Update(int id,Category cat)
        {
            if(cat == null)
                return BadRequest();
            _repository.Update(cat);
            return cat;
        }
        [HttpDelete("remove/{id}")]
        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            return Ok();
        }
    
    }
}