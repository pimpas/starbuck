using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Starbuck.Business.Interfaces;
using Starbuck.Business.Models;
using Starbuck.Api.ViewModels;
using Starbuck.Business.Notifications;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Starbuck.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtrasController : ControllerBase
    {
       
        private readonly IExtraRepository _extraRepository;
        private readonly INotificator _notificator;

        public ExtrasController(IExtraRepository extraRepository, INotificator notificator)
        {
            _extraRepository = extraRepository;
            _notificator = notificator;
        }
        // GET: api/<ExtrasController>
        [HttpGet]
        public async Task<IEnumerable<Extra>> Get()
        {
            return await _extraRepository.GetAll();
        }

        // GET api/<ExtrasController>/5
        [HttpGet("{id}")]
        public async Task<Extra> Get(Guid id)
        {
            return await _extraRepository.GetById(id);
        }

        // POST api/<ExtrasController>
        [HttpPost]
        public async void Post([FromBody] ExtraViewModel extraViewModel)
        {
            var extra = new Extra();
            extra.Name = extraViewModel.Name;
            extra.Price = extraViewModel.Price;
            await _extraRepository.Add(extra);
        }

        // PUT api/<ExtrasController>/5
        [HttpPut("{id}")]
        public async void Put(Guid id, [FromBody] ExtraViewModel extraViewModel)
        {
            if (id != extraViewModel.Id)
            {
                _notificator.Handle(new Notification("The ids are different"));
            }

            var updateCategory = await _extraRepository.GetById(id);
            updateCategory.Name = extraViewModel.Name;
            updateCategory.Price = extraViewModel.Price;
        }

        // DELETE api/<ExtrasController>/5
        [HttpDelete("{id}")]
        public async void Delete(Guid id)
        {
            var extra = await _extraRepository.GetById(id);

            await _extraRepository.Remove(id);
        }
    }
}
