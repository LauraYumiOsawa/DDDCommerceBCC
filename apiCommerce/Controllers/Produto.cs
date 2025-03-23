using Microsoft.AspNetCore.Mvc;
using Commerce.Domain;
using Commerce.Infra.Interfaces;
using System.Threading.Tasks;

namespace apiCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var produtos = await _produtoRepository.GetAll();
            return Ok(produtos);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Produto produto)
        {
            var result = await _produtoRepository.Add(produto);
            if (!result) return BadRequest("ErrOUUUUU");

            return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Produto produto)
        {
            if (produto == null || id != produto.Id)
                return BadRequest("TA TUDO ERRADO.");

            var result = await _produtoRepository.Update(id, produto);
            if (!result) return NotFound($"SKILL ISSUE PRODUTO - {id}");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _produtoRepository.Delete(id);
            if (!result) return NotFound("PRODUTO TA LA EM CASA MAS N TA AQUi.");

            return NoContent();
        }
    }
}