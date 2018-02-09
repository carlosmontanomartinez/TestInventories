using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Services.Description;
using CinepolisApiKey.Data.Api.Generic;
using Inventories.Data.Interfaces;
using Inventories.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using CinepolisApiKey.Data.Api.Interfaces;
using Inventories.Data.EntityFramework.Context;
using Inventories.Data.Models.Api;
using Inventories.Infrastructure.Interfaces;
using Inventories.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Inventories.Controllers
{
    [Route("")]
    public class ValuesController : Controller
    {
        private readonly IApiConfigurable _errorsConfiguration;
        private readonly IConsessionCinemaService _consessionCinemaService;
        private readonly IStatusService _statusService;
        private readonly ICinemaService _cinemaService;

        public ValuesController(
            IApiConfigurable errorsConfiguration, 
            IConsessionCinemaService consessionService, 
            IStatusService statusService,
            ICinemaService cinemaService)
        {
            _errorsConfiguration = errorsConfiguration;
            _consessionCinemaService = consessionService;
            _statusService = statusService;
            _cinemaService = cinemaService;
        }
    
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<string>> Get(List<Inventory> inventories)
        {
            try
            {
                foreach (var item in inventories)
                {
                    var cinema = await _cinemaService.GetAsync(item.CinemaVistaId);
                    //var consessionCinema = await _consessionCinemaService.GetAsync(cinema.Id, item.Hopk);

                    var status = await _statusService.GetAsync(item.IsAvailable ? "Active" : "Inactive");
                    //consessionCinema.Stock = item.StokQuantity;
                    //consessionCinema.Status = status;

                    //await _consessionCinemaService.UpdateAsyn(consessionCinema, )
                }
                
                var errors = _errorsConfiguration;
                return new string[] { _errorsConfiguration?.ApplicationName, _errorsConfiguration?.Version };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
