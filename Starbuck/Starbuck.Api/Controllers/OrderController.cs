using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Starbuck.Business.Interfaces;
using Starbuck.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starbuck.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IExtraRepository _extraRepository;
        private readonly IProductRepository _productRepository;
        private readonly INotificator _notificator;

        public OrderController(ICategoryRepository categoryRepository, IExtraRepository extraRepository, IProductRepository productRepository, INotificator notificator)
        {
            _categoryRepository = categoryRepository;
            _extraRepository = extraRepository;
            _productRepository = productRepository;
            _notificator = notificator;
        }
        [HttpPost]
        public async Task<string> Post([FromBody] Order order)
        {
            var product = await _productRepository.GetById(order.Product.Id);
            var extras = order.Extras;

            var totalPrice = product.Price + extras.Sum(x => x.Price);
            if (product.Stock > 0) { 
                if(totalPrice<= order.MoneySent)
                {
                    var productUpdate = _productRepository.GetById(order.Product.Id).Result;
                    productUpdate.Stock -= 1;
                    await _productRepository.Update(productUpdate);
                
                    return $"order being executed. Change: {totalPrice - order.MoneySent}";
                }
                else
                {
                    return ("please pay the price of the items.");
                }
            }
            else
            {
                return ("item out of stock.");
            }
        }

        
    }
}
