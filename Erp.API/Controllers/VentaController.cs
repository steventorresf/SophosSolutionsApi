using Erp.Dto;
using Erp.Facade.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Erp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaFacade facade;

        public VentaController(IVentaFacade facade)
        {
            this.facade = facade;
        }

        [HttpPost]
        public IActionResult Create([FromBody] VentaRequestDto request)
        {
            var response = facade.Create(request);
            return Ok(response);
        }

        [HttpGet("Get/{idVenta}")]
        public IActionResult Get(int idVenta)
        {
            var response = facade.Get(idVenta);
            return Ok(response);
        }
    }
}
