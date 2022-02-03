using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Starbuck.Business.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using Starbuck.Business.Models;
using Starbuck.Api.ViewModels;
using Starbuck.Business.Notifications;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Starbuck.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly INotificator _notificator;

        public CategoriesController(ICategoryRepository categoryRepository, INotificator notificator)
        {
            _categoryRepository = categoryRepository;
            _notificator = notificator;
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
        public async void Post([FromBody] CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var category = new Category();
                category.Id = categoryViewModel.Id;
                category.Name = categoryViewModel.Name;
               await _categoryRepository.Add(category);
            }
            var errors = ModelState.Values.SelectMany(e => e.Errors);

            foreach (var error in errors)
            {
                _notificator.Handle(new Notification(error.ErrorMessage));
            }

        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public async void Put(Guid id, [FromBody] CategoryViewModel categoryViewModel)
        {
            if(id != categoryViewModel.Id)
            {
                _notificator.Handle(new Notification("The ids are different"));
            }
            var updateProduct = await _categoryRepository.GetById(categoryViewModel.Id);
            updateProduct.Name = categoryViewModel.Name;
            await _categoryRepository.Update(updateProduct);
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public async void Delete(Guid id)
        {
            var category = await _categoryRepository.GetById(id);

            await _categoryRepository.Remove(id);
        }
    }
}
