using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Starbuck.Business.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using Starbuck.Business.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Starbuck.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            return await _categoryRepository.GetAll();
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{name}")]
        public Category Get(string name)
        {
            return _categoryRepository.GetAll().Result.FirstOrDefault(n=> n.Name == name);
            
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
