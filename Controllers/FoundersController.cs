using ClientService.Models.Requests.FounderModels;
using ClientService.Models.Responses.FounderModels;
using ClientService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ClientService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoundersController : ControllerBase
    {
        private readonly IFounderManager _founderManager;

        public FoundersController(IFounderManager founderManager)
        {
            _founderManager = founderManager;
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetFounderResponse), 200)]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            var founder = await _founderManager.GetAsync(id);

            return Ok(founder);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<IActionResult> Create([FromBody, Required] CreateFounderRequest request)
        {
            var founderId = await _founderManager.CreateAsync(request);

            return Ok(founderId);
        }

        [HttpPut]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Update([FromBody, Required] UpdateFounderRequest request)
        {
            await _founderManager.UpdateAsync(request);

            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Delete([FromBody] DeleteFounderRequest request)
        {
            await _founderManager.DeleteAsync(request);

            return Ok();
        }
    }
}
