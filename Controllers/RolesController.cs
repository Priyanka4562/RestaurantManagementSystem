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
    public class RoleController : ControllerBase
    {
        ICRUDRepository<Roles, int> _repository;
        public RoleController(ICRUDRepository<Roles,int> repository) 
            =>_repository = repository;
        
        
        public ActionResult<IEnumerable<Roles>> Get()
        {
           
            var items = _repository.GetAll();
            return items.ToList();
        }
        [HttpGet("{id}")]

        public ActionResult<Roles> GetDetails(int id)
        {
            var item =_repository.GetDetails(id);
            if(item == null)
                return NotFound();
            return item;

        }

        [HttpPost("addnew")]

        public ActionResult<Roles> Create(Roles rol)
        {
            if(rol == null)
            {
                return BadRequest();
            }

            _repository.Create(rol);
            return rol;
        }

        [HttpPut("update/{id}")]
        public ActionResult<Roles> Update(int id,Roles rol)
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