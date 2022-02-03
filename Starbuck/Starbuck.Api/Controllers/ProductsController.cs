using Microsoft.AspNetCore.Mvc;
using Starbuck.Business.Interfaces;
using System;
using System.Collections.Generic;
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
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly INotificator _notificator;

        public ProductsController(IProductRepository productRepository, INotificator notificator)
        {
            _productRepository = productRepository;
            _notificator = notificator;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await  _productRepository.GetAll();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ProductViewModel> Get(Guid id)
        {
            var product = await _productRepository.GetById(id);
            ProductViewModel pvm = new ProductViewModel();
            pvm.Id = product.Id;
            pvm.Name = product.Name;
            pvm.Price = product.Price;
            return pvm;
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async void Post([FromBody] ProductViewModel productViewModel)
        {
            Product p = new Product();
            p.CategoryId = productViewModel.CategoryId;
            p.Name = productViewModel.Name;
            p.Price = productViewModel.Price;
            p.Stock = productViewModel.Stock;

            
            try
            {
             await _productRepository.Add(p);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async void Put(Guid id, [FromBody] ProductViewModel productViewModel)
        {
            if (id != productViewModel.Id)
            {
                _notificator.Handle(new Notification("The ids are different"));
            }
            var p = await _productRepository.GetById(id);
            p.CategoryId = productViewModel.CategoryId;
            p.Name = productViewModel.Name;
            p.Price = productViewModel.Price;
            p.Stock = productViewModel.Stock;

            await _productRepository.Add(p);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async void Delete(Guid id)
        {
            var product = await _productRepository.GetById(id);
            await _productRepository.Remove(product.Id);
        }
    }
}
