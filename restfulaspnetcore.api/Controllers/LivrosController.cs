using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restfulaspnetcore.api.Infrastructure.Data;
using restfulaspnetcore.api.Model;

namespace restfulaspnetcore.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly ContextoAplicacao _contexto;

        public LivrosController(ContextoAplicacao contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<IActionResult> GetTask() {
            var _data = await _contexto.Livros.AsNoTracking().ToListAsync();
            return Ok(_data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id) {
            var _data = await _contexto.Livros.FirstOrDefaultAsync(w => w.Id == id);
            if (_data == null) return NotFound();
            return Ok(_data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Livro livro) {
            if (livro == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            await _contexto.Livros.AddAsync(livro);
            await _contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new {id = livro.Id}, livro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put (Guid id, [FromBody]Livro livro) {
            if (livro == null) return BadRequest();
            if (livro.Id != id) return BadRequest();
            var _registroExistente = await _contexto.Livros.AnyAsync(w => w.Id == id);
            if (!_registroExistente) return NotFound();
            if (!ModelState.IsValid) return BadRequest();
            _contexto.Livros.Update(livro);
            await _contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) {
            var _livro = await _contexto.Livros.FindAsync(id);
            if (_livro == null) return NotFound();
            _contexto.Livros.Remove(_livro);
            await _contexto.SaveChangesAsync();
            return NoContent();
        }
    }
}