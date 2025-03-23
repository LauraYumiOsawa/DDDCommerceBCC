using Microsoft.AspNetCore.Mvc;
using Commerce.Domain;
using Commerce.Infra.Interfaces;
using System.Threading.Tasks;

namespace apiCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidosController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pedidos = await _pedidoRepository.GetAll();
            return Ok(pedidos);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pedido pedido)
        {
            var result = await _pedidoRepository.Add(pedido);
            if (!result) return BadRequest("ErrOUUUUU.");

            return CreatedAtAction(nameof(Get), new { id = pedido.Id }, pedido);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Pedido pedido)
        {
            if (pedido == null || id != pedido.Id)
                return BadRequest("TA TUDO ERRADO.");

            var result = await _pedidoRepository.Update(id, pedido);
            if (!result) return NotFound($"SKILL ISSUE PRODUTO  - {id}");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _pedidoRepository.Delete(id);
            if (!result) return NotFound("PEDIDO TA LA EM CASA MAS N TA AQUi.");

            return NoContent();
        }
    }
}