using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using UnitOfWork;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/Customer
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Customer/5
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {

            return Ok(_unitOfWork.Customer.GetById(id));
        }

        [HttpGet]
        [Route("GetPaginatedCustomer/{page:int}/{rows:int}")]
        public IActionResult GetPaginatedCustomer(int page, int rows)
        {

            return Ok(_unitOfWork.Customer.CustomerPagedList(page,rows));
        }

        // POST: api/Customer
        [HttpPost]
        public IActionResult Post([FromBody]Customer customer)
        {
            if (!ModelState.IsValid) return BadRequest();
            return Ok(_unitOfWork.Customer.Insert(customer));
        }

        // PUT: api/Customer/5
        [HttpPut]
        public IActionResult Put([FromBody]Customer customer)
        {
            if(ModelState.IsValid && _unitOfWork.Customer.Update(customer))
            {
                return Ok(new { Message = "The Customer is updated" });
            }
            return BadRequest();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromBody]Customer customer)
        {
            if (customer.Id > 0)
                return Ok(_unitOfWork.Customer.Delete(customer));
            return BadRequest();
        }
    }
}
