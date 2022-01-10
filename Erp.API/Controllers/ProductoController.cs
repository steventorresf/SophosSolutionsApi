using Erp.Dto;
using Erp.Facade.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Erp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoFacade facade;

        public ProductoController(IProductoFacade facade)
        {
            this.facade = facade;
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductoDto request)
        {
            var response = facade.Create(request);
            return Ok(response);
        }

        [HttpDelete("{idProducto}")]
        public IActionResult Delete(int idProducto)
        {
            var response = facade.Delete(idProducto);
            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = facade.GetAll();
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update([FromBody] ProductoDto request)
        {
            var response = facade.Update(request);
            return Ok(response);
        }
    }
}
