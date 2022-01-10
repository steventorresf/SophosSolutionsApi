using Erp.Dto;
using Erp.Facade.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Erp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteFacade facade;

        public ClienteController(IClienteFacade facade)
        {
            this.facade = facade;
        }

        [HttpPost]
        public IActionResult Create([FromBody] ClienteDto request)
        {
            var response = facade.Create(request);
            return Ok(response);
        }

        [HttpDelete("{idCliente}")]
        public IActionResult Delete(int idCliente)
        {
            var response = facade.Delete(idCliente);
            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = facade.GetAll();
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update([FromBody] ClienteDto request)
        {
            var response = facade.Update(request);
            return Ok(response);
        }
    }
}
