using ClientService.Models.Requests.ClientModels;
using ClientService.Models.Responses.ClientModels;
using ClientServise.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ClientService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientManager _clientManager;

        public ClientsController(IClientManager clientManager)
        {
            _clientManager = clientManager;
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetClientResponse), 200)]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            var client = await _clientManager.GetAsync(id);

            return Ok(client);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<IActionResult> Create([FromBody, Required] CreateClientRequest request)
        {
            var clientId = await _clientManager.CreateAsync(request);

            return Ok(clientId);
        }

        [HttpPut]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Update([FromBody, Required] UpdateClientRequest request)
        {
            await _clientManager.UpdateAsync(request);

            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Delete([FromBody] DeleteClientRequest request)
        {
            await _clientManager.DeleteAsync(request);

            return Ok();
        }
    }
}

