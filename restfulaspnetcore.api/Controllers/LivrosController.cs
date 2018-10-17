using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restfulaspnetcore.api.DataTransport;
using restfulaspnetcore.api.Infrastructure.Data;
using restfulaspnetcore.api.Model;

namespace restfulaspnetcore.api.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion( "0.9", Deprecated = true )]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly ContextoAplicacao _contexto;

        public LivrosController(ContextoAplicacao contexto)
        {
            _contexto = contexto;
        }

        /// <summary>
        /// Obtém a lista de livros
        /// </summary>
        /// <remarks>
        /// Esse trecho é utilizado para detalhar um pouco melhor o funcionamento desse recuro. 
        /// Numa abordagem DataDrive, a consulta de uma informação ou - mais comumente - a inclusão, remoção ou deleteção de dados pode servir de gatilho para uma sequencia de eventos e processos de negócio</remarks>
        /// <returns>Lista de livros</returns>
        /// <response code="200">Lista de livros resultante da pesquisa</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Livro>), 200)]
        public async Task<IActionResult> GetTask() {
            var _data = await _contexto.Livros.AsNoTracking().ToListAsync();
            return Ok(_data);
        }

        /// <summary>
        /// Pesquisa um livro pela sua identificação.
        /// </summary>
        /// <param name="id">Identificação do livro</param>
        /// <returns>Livro resultado da pesquisa</returns>
        /// <response code="200">Livro pesquisado</response>
        /// <response code="404">Não foi encontrado resultado para a pesquisa.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Livro), 200)]
        [ProducesResponseType(typeof(Erro), 404)]
        public async Task<IActionResult> Get(Guid id) {
            var _data = await _contexto.Livros.FirstOrDefaultAsync(w => w.Id == id);
            if (_data == null) return NotFound(new Erro(-1, "Não foi possível localizar o livro desejado."));
            return Ok(_data);
        }

        /// <summary>
        /// Registra um livro
        /// </summary>
        /// <param name="livro">Dados do livro a ser registrado</param>
        /// <returns>O livro recém registrado</returns>
        /// <response code="201">Livro recém registrado</response>
        /// <response code="400">Solicitação de registro contém informações inválidas. Consulte a resposta de erro para detalhes.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Livro), 201)]
        [ProducesResponseType(typeof(Erro), 400)]
        public async Task<IActionResult> Post([FromBody]Livro livro) {
            if (livro == null) return BadRequest(new Erro(-2, "É necessário informar para o livro."));
            if (!ModelState.IsValid) return BadRequest(new Erro(-3, "Os dados informados são inválidos."));
            await _contexto.Livros.AddAsync(livro);
            await _contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new {id = livro.Id}, livro);
        }

        /// <summary>
        /// Atualiza um livro
        /// </summary>
        /// <param name="id">Identificação do livro</param>
        /// <param name="livro">Dados a serem atualizados para o livro</param>
        /// <returns>Sem conteúdo. O registro do livro deve manter-se identico ao informado como parametro.</returns>
        /// <response code="204">Sem conteúdo. O registro do livro deve manter-se identico ao informado como parametro.</response>
        /// <response code="400">Solicitação de atualização contém informações inválidas. Consulte a resposta de erro para detalhes.</response>
        /// <response code="404">Atualização não pode ser executada porque não foi encontrado um livro com a identificação informada.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(Erro), 400)]
        [ProducesResponseType(typeof(Erro), 404)]
        public async Task<IActionResult> Put (Guid id, [FromBody]Livro livro) {
            if (livro == null) return BadRequest(new Erro(-2, "É necessário informar para o livro."));
            if (livro.Id != id) return BadRequest(new Erro(-4, "É permitido alterar apenas dados para o livro informado."));
            var _registroExistente = await _contexto.Livros.AnyAsync(w => w.Id == id);
            if (!_registroExistente) return NotFound(new Erro(-5, "O livro não pode ser encontrado."));
            if (!ModelState.IsValid) return BadRequest(new Erro(-3, "Os dados informados são inválidos."));
            _contexto.Livros.Update(livro);
            await _contexto.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Apaga o livro
        /// </summary>
        /// <param name="id">Identificação do livro</param>
        /// <returns>Sem conteúdo.</returns>
        /// <response code="204">Sem conteúdo. </response>
        /// <response code="404">Deleção não pode ser executada porque não foi encontrado um livro com a identificação informada.</response>
        [HttpDelete("{id}")]
        [MapToApiVersion( "1.0" )]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(Erro), 404)]
        public async Task<IActionResult> Delete(Guid id) {
            var _livro = await _contexto.Livros.FindAsync(id);
            if (_livro == null) return NotFound(new Erro(-5, "O livro não pode ser encontrado."));
            _contexto.Livros.Remove(_livro);
            await _contexto.SaveChangesAsync();
            return NoContent();
        }
    }
}